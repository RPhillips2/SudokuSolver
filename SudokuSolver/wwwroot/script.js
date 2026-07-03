document.addEventListener('DOMContentLoaded', () => {
    initializeGrid();
    setupFormSubmission();
});

function initializeGrid() {
    const gridContainer = document.querySelector('.grid');
    
    for (let i = 0; i < 81; i++) {
        const cellDiv = document.createElement('div');
        cellDiv.className = 'cell';
        
        const input = document.createElement('input');
        input.type = 'number';
        input.min = '0';
        input.max = '9';
        input.placeholder = '0';
        input.dataset.index = i;
        
        // Allow only single digit input
        input.addEventListener('input', (e) => {
            if (e.target.value.length > 1) {
                e.target.value = e.target.value.slice(-1);
            }
            if (e.target.value < 0 || e.target.value > 9) {
                e.target.value = '';
            }
        });
        
        // Move to next cell on Enter
        input.addEventListener('keydown', (e) => {
            if (e.key === 'Enter') {
                const nextInput = document.querySelector(`input[data-index="${i + 1}"]`);
                if (nextInput) nextInput.focus();
            }
        });
        
        cellDiv.appendChild(input);
        gridContainer.appendChild(cellDiv);
    }
}

function setupFormSubmission() {
    const form = document.getElementById('sudokuForm');
    
    form.addEventListener('submit', (e) => {
        e.preventDefault();
        submitSudoku();
    });
}

function getSudokuGrid() {
    const inputs = document.querySelectorAll('.cell input');
    const grid = [];
    
    inputs.forEach((input, index) => {
        const row = Math.floor(index / 9);
        const col = index % 9;
        
        if (!grid[row]) grid[row] = [];
        grid[row][col] = input.value ? parseInt(input.value) : 0;
    });
    
    return grid;
}

function submitSudoku() {
    const grid = getSudokuGrid();
    const resultDiv = document.getElementById('result');
    
    // Validate the grid (basic validation)
    if (!isValidSudoku(grid)) {
        resultDiv.className = 'result error';
        resultDiv.textContent = 'Invalid Sudoku puzzle. Please check for duplicate numbers in rows, columns, or 3x3 boxes.';
        return;
    }
    
    // Log the grid (in a real app, send this to your backend)
    console.log('Sudoku Grid:', grid);
    
    resultDiv.className = 'result success';
    resultDiv.textContent = 'Sudoku puzzle submitted! Check the console for the grid data.';
}

function isValidSudoku(grid) {
    // Check rows
    for (let row = 0; row < 9; row++) {
        const seen = new Set();
        for (let col = 0; col < 9; col++) {
            const num = grid[row][col];
            if (num !== 0) {
                if (seen.has(num)) return false;
                seen.add(num);
            }
        }
    }
    
    // Check columns
    for (let col = 0; col < 9; col++) {
        const seen = new Set();
        for (let row = 0; row < 9; row++) {
            const num = grid[row][col];
            if (num !== 0) {
                if (seen.has(num)) return false;
                seen.add(num);
            }
        }
    }
    
    // Check 3x3 boxes
    for (let boxRow = 0; boxRow < 3; boxRow++) {
        for (let boxCol = 0; boxCol < 3; boxCol++) {
            const seen = new Set();
            for (let i = 0; i < 3; i++) {
                for (let j = 0; j < 3; j++) {
                    const num = grid[boxRow * 3 + i][boxCol * 3 + j];
                    if (num !== 0) {
                        if (seen.has(num)) return false;
                        seen.add(num);
                    }
                }
            }
        }
    }
    
    return true;
}
