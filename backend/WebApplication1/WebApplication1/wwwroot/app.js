

var playername = "Guest";
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
function quitGame() {
    console.log("Quite Game!")
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

    PlayerId = 0;
    numberofcards = 2;
    if (PlayerId == 0) {
        this.document.getElementById("playercard").className = "dealercard";
        if (numberofcards == 2) {
            document.getElementById("playercard").style.left="460"

        }
        else if (numberofcards == 3) {
            document.getElementById("playercard").style.left="470"

        }
        else if (numberofcards == 4) {
            document.getElementById("playercard").style.left="480"

        }
        else if (numberofcards == 5) {
            document.getElementById("playercard").style.left="490"

        }
    }
    else if (PlayerId == 1) {
    this.document.getElementById("playercard").className = "playeronecard";
        if (numberofcards == 2) {
            document.getElementById("playercard").style.left="200"

        }
        else if (numberofcards == 3) {
            document.getElementById("playercard").style.left="210"

        }
        else if (numberofcards == 4) {
            document.getElementById("playercard").style.left="220"

        }
        else if (numberofcards == 5) {
            document.getElementById("playercard").style.left="230"

        }
    }
    else if (PlayerId == 2) {
        this.document.getElementById("playercard").className = "playertwocard";
        if (numberofcards == 2) {
            document.getElementById("playercard").style.left="410"

        }
        else if (numberofcards == 3) {
            document.getElementById("playercard").style.left="420"

        }
        else if (numberofcards == 4) {
            document.getElementById("playercard").style.left="430"

        }
        else if (numberofcards == 5) {
            document.getElementById("playercard").style.left="440"

        }
        
    }
    else if (PlayerId == 3) {
        this.document.getElementById("playercard").className = "playerthreecard";
        if (numberofcards == 2) {
            document.getElementById("playercard").style.left="645"

        }
        else if (numberofcards == 3) {
            document.getElementById("playercard").style.left="655"

        }
        else if (numberofcards == 4) {
            document.getElementById("playercard").style.left="665"

        }
        else if (numberofcards == 5) {
            document.getElementById("playercard").style.left="675"

        }
    }
    else {
        console.log("errori")
        
    }
    
    
    
<<<<<<< HEAD
};

//init
$(function () {
    // your code goes here
    
    console.log("Joining game!");
    var xmlHttp = new XMLHttpRequest();
    xmlHttp.open("Get", "https://localhost:5001/blackjack", false); // false for synchronous request
    xmlHttp.send();
    console.log(xmlHttp.responseText);
    var join = new XMLHttpRequest();
    join.open("POST", "https://localhost:5001/blackjack/"+playername, true); // false for synchronous request
    join.send();
    console.log(join.responseText);
});
=======
}
>>>>>>> f641d39191c67654551f45dfff908408b23e4190







    
    