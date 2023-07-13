// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function showPossibleMoveDiv(indexes) {   
    hideAllPossibleMoveDiv(indexes)
    console.log(indexes);
    for (const index of indexes) {
        let possibleMoveDiv = document.querySelector('#cell-' + index);
        possibleMoveDiv.hidden = !possibleMoveDiv.hidden;
    }
    
}

function hideAllPossibleMoveDiv(indexes) {
    let possibleMoveDivs = document.querySelectorAll('.possible-move');
    for (const element of possibleMoveDivs) {
        if (!indexes.includes(parseInt(element.id.replace('cell-', ''))) || element.hidden == false) {
            element.hidden = true;
        }
    }
}
