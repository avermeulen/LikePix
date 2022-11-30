const connection = new signalR.HubConnectionBuilder().withUrl("/likes").build();

const counterElem = document.querySelector('.counter');

let counter = 0;

connection.on("Liked", function(counter) {
    counterElem.innerText = counter;
});

connection.on("Unliked", function(counter) {
    counterElem.innerText = counter;
});

connection.on("Update", function(counter) {
    counterElem.innerText = counter;
});

function like(){
    console.log("liked")
    connection.invoke("Like", "").catch(function (err) {
        return console.error(err.toString());
    });
}

function unlike(){
    console.log("unliked")
    connection.invoke("Unlike", "").catch(function (err) {
        return console.error(err.toString());
    });
}

connection.start().then(function () {

    connection.invoke("Update", "").catch(function (err) {
        return console.error(err.toString());
    });


}).catch(function (err) {
    return console.error(err.toString());
});





