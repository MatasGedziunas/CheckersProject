// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let lastClickedDiv = null;

function showPossibleMoveDiv(clickedDiv) {
    hideAllPossibleMoveDiv();
    let indexes = getAllPossibleMoveIndexes(clickedDiv.id.split("-")[1]);
    if (lastClickedDiv === clickedDiv) {
        lastClickedDiv = null;
    } else {
        for (const index of indexes) {
            let possibleMoveDiv = document.querySelector('#cell-' + index);
            possibleMoveDiv.hidden = !possibleMoveDiv.hidden;
        }
        lastClickedDiv = clickedDiv;
    }
}

function hideAllPossibleMoveDiv() {
    let possibleMoveDivs = document.querySelectorAll('.possible-move');
    for (const element of possibleMoveDivs) {

        element.hidden = true;

    }
}

function getAllPossibleMoveIndexes(indexFrom) {
    let possibleMoveIndexes = [];
    $.ajax({
        url: '/Home/GetPossibleMoves',
        type: 'GET',
        data: { index: indexFrom },
        async: false,
        success: function (response) {
            possibleMoveIndexes = response;
        }
    });
    return possibleMoveIndexes;
}


function makeMove(clickedPossibleMoveDiv) {
    let indexFrom = lastClickedDiv.id.split('-')[1]; 
    let indexTo = clickedPossibleMoveDiv.id.split('-')[1];
        $.ajax({
            url: '/Home/MakeMove',
            type: 'POST',
            data: { indexFrom: indexFrom, indexTo: indexTo },
            success: function (response) {
                // handle the response from the server
            }
        });
    swapImages(getDivFirstInnerChild(lastClickedDiv), clickedPossibleMoveDiv);
}


// get possible move wrapper div and swap the inner htmls;
function swapImages(divFrom, divTo) {
    let temp = divFrom.className;
    divFrom.className = divTo.className;
    divTo.className = temp;
    hideAllPossibleMoveDiv();
    console.log(divFrom);
}

function getDivFirstInnerChild(div) {
    return div.children[0];
}



