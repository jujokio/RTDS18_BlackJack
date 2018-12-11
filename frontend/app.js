
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

function joinGame() {
    console.log("Joining game!");
}
//getting card from available deck that is stored in the server
function httpGetCard(theUrl)
{
    var xmlHttp = new XMLHttpRequest();
    xmlHttp.open( "GET", theUrl, false ); // false for synchronous request
    xmlHttp.send( null );
    return xmlHttp.responseText;
}

function getCardImg (name) {
   
    var name = "d5";
    var card = 5;
    if (card == 1) {
        console.log("card oli 1");
        fullname = os.path.join("cards/", name)
    }
    else{
        url = "cards/d5.png";
        // url = "cards/"+name+".png";
        console.log(url);

        return url;
    }
}
function getPlayerNumber() {
    if (PlayerId == 1) {

    }
    else if (PlayerId == 2) {
        
    }
    else if (PlayerId == 3) {
        
    }
    else if (PlayerId == 4) {
        
    }
    else {
        document.getElementById("playercard").className = "playeronecard";
    }
}






    
    