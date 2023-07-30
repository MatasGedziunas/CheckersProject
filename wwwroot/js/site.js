// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let lastClickedDiv = null;

function GenerateCorrectChessBoard() {

}

function ShowPossibleMoveDiv(clickedDiv, gameId) {
    hideAllPossibleMoveDiv();
    let indexes = getAllPossibleMoveIndexes(clickedDiv.id.split("-")[1], gameId);
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

function HideAllPossibleMoveDiv() {
    let possibleMoveDivs = document.querySelectorAll('.possible-move');
    for (const element of possibleMoveDivs) {

        element.hidden = true;

    }
}

function GetAllPossibleMoveIndexes(indexFrom, gameId) {
    let possibleMoveIndexes = [];
    $.ajax({
        url: '/Games/GetPossibleMoves',
        type: 'GET',
        data: { index: indexFrom, gameId: gameId },
        async: false,
        success: function (response) {
            possibleMoveIndexes = response;
        }
    });
    console.log(possibleMoveIndexes);
    return possibleMoveIndexes;
}


function MakeMove(clickedPossibleMoveDiv, gameId, userId) {
    let indexFrom = lastClickedDiv.id.split('-')[1]; 
    let indexTo = clickedPossibleMoveDiv.id.split('-')[1];
        $.ajax({
            url: '/Games/MakeMove',
            type: 'POST',
            data: { indexFrom: indexFrom, indexTo: indexTo, gameId: gameId, userId: userId},
            success: function (response) {
                // handle the response from the server
            }
        });
    swapImages(getDivFirstInnerChild(lastClickedDiv), clickedPossibleMoveDiv);
}




// get possible move wrapper div and swap the inner htmls;
function SwapImages(divFrom, divTo) {
    let temp = divFrom.className;
    divFrom.className = divTo.className;
    divTo.className = temp;
    hideAllPossibleMoveDiv();
    console.log(divFrom);
}

function GetDivFirstInnerChild(div) {
    return div.children[0];
}



