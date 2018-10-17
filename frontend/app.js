
//openform and closeform are for chat
function openForm() {
    document.getElementById("myForm").style.display = "block";
}

function closeForm() {
    document.getElementById("myForm").style.display = "none";
}
//hitrequest to get a card nd to sen getrequest to server
function sendHitRequest() {
    var my_turn = false;
    if(my_turn) {
        httpGetCard();
    } 
    else {
        window.alert("Wait for Your turn!!!");
    }
    

}

function sendStandRequest() {

}
//getting card from available deck that is stored in the server
function httpGetCard(theUrl)
{
    var xmlHttp = new XMLHttpRequest();
    xmlHttp.open( "GET", theUrl, false ); // false for synchronous request
    xmlHttp.send( null );
    return xmlHttp.responseText;
}






    
    