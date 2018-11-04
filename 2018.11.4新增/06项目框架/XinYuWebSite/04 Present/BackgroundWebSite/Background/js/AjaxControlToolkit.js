
// Show & hide div
function showDiv(divID) {

    var div = document.getElementById(divID);
    if (div) {
        div.style.display = "";
    }
}

function hideDiv(divID) {

    var div = document.getElementById(divID);
    if (div) {
        div.style.display = "none";
    }
}


// Modal Popup
function showModalPopupBoard(boardBehaviorID) {

    var modalPopupBehavior = $find(boardBehaviorID);
    if (modalPopupBehavior) {
        modalPopupBehavior.show();
    }
    return false;
}

function hideModalPopupBoard(boardBehaviorID) {

    var modalPopupBehavior = $find(boardBehaviorID);
    if (modalPopupBehavior) {
        modalPopupBehavior.hide();
    }
    return false;
}

function showModalPopupBoardWithDiv(divID, boardBehaviorID) {
    
    var modalPopupBehavior = $find(boardBehaviorID);
    if (modalPopupBehavior) {
        showDiv(divID);   
        modalPopupBehavior.show();
    }
    else {
        showPopWin(divID, null);
    }

    return false;
}

function hideModalPopupBoardWithDiv(divID, boardBehaviorID) {
    
    var modalPopupBehavior = $find(boardBehaviorID);
    if (modalPopupBehavior) {
        hideDiv(divID);
        modalPopupBehavior.hide();
    }
    else {
        hidePopWin(divID, null);
    }
    
    return false;
}


// Collapse  
function showCollapsePanel(behaviorID) {
    var behavior = $find(behaviorID);
    if (behavior) {
        behavior.expandPanel();
    }
}

function hideCollapsePanel(behaviorID) {

    var behavior = $find(behaviorID);
    if (behavior) {
        behavior.collapsePanel();
    }
}

function cllapsePanel(pnlID, ibtnID) {

    var panel = document.getElementById(pnlID);
    var ibtn = document.getElementById(ibtnID);
    
    if (panel && ibtn) {
        
        if (panel.style.display == '') {
            panel.style.display = 'none';
            ibtn.src = '../Images/Collapsible/expand.jpg';
        }
        else {
            panel.style.display = '';
            ibtn.src = '../Images/Collapsible/collapse.jpg';
        }
    }
    return false;
} 



/**
 * Hides all drop down form select boxes on the screen so they do not appear above the mask layer.
 * IE has a problem with wanted select form tags to always be the topmost z-index or layer
 *
 * Thanks for the code Scott!
 */
function hideSelectBoxes() {
  var x = document.getElementsByTagName("SELECT");

  for (i=0;x && i < x.length; i++) {
    x[i].style.visibility = "hidden";
  }
}

/**
 * Makes all drop down form select boxes on the screen visible so they do not 
 * reappear after the dialog is closed.
 * 
 * IE has a problem with wanting select form tags to always be the 
 * topmost z-index or layer.
 */
function displaySelectBoxes() {
  var x = document.getElementsByTagName("SELECT");

  for (i=0;x && i < x.length; i++){
    x[i].style.visibility = "visible";
  }
}

