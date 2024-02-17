"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;

connection.on("SendMessage", function ( message) {
   // var li = document.createElement("li");
    const outerDiv = document.createElement('div');
    outerDiv.classList.add('flex', 'w-full', 'mt-2', 'space-x-3');

    // Create the first child div
    const avatarDiv = document.createElement('div');
    avatarDiv.classList.add('flex-shrink-0', 'h-10', 'w-10', 'rounded-full', 'bg-gray-300');

    // Create the second child div
    const messageDiv = document.createElement('div');
    messageDiv.classList.add('bg-gray-300', 'p-3', 'rounded-r-lg', 'rounded-bl-lg');

    // Create the paragraph element inside the message div
    const paragraph = document.createElement('p');
    paragraph.classList.add('text-sm');
    paragraph.textContent = `${message}`;

    // Append the paragraph to the message div
    messageDiv.appendChild(paragraph);

    // Create the timestamp span element
    const timestampSpan = document.createElement('span');
    timestampSpan.classList.add('text-xs', 'text-gray-500', 'leading-none');
    var currentDateUTC = new Date();
    timestampSpan.textContent = `${currentDateUTC.toString()}`;

    // Append the message div and timestamp span to the second child div
    messageDiv.appendChild(timestampSpan);
    // Append the first and second child divs to the outermost div
    outerDiv.appendChild(avatarDiv);
    outerDiv.appendChild(messageDiv);

    document.getElementById("messagesList").appendChild(outerDiv);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you
    // should be aware of possible script injection concerns.
    // outerDiv.textContent = `${user} says ${message}`;
 
 });

connection.start().then(function () {

    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
 
    var sender = document.getElementById("userInput").value;
    var recever = document.getElementById("userInput2").value;
   

    var message = document.getElementById("messageInput").value;
    document.getElementById("messageInput").value = "";

    connection.invoke("SendMessage", sender,recever, message).catch(function (err) {
        return console.error(err.toString());
    });
   
    event.preventDefault();
    document.getElementById("messageInput").textContent = "";
});







connection.on("ReceiveMessage", function (  message) {
    // var li = document.createElement("li");
    const outerDiv = document.createElement('div');
    outerDiv.classList.add('flex', 'w-full', 'mt-2', 'space-x-3', 'max-w-xs', 'ml-auto', 'justify-end');

    // Create the first child div
    const messageDiv = document.createElement('div');
    messageDiv.classList.add('bg-blue-600', 'text-white', 'p-3', 'rounded-l-lg', 'rounded-br-lg');

    // Create the paragraph element inside the message div
    const paragraph = document.createElement('p');
    paragraph.classList.add('text-sm');
    paragraph.textContent = `${message}`;

    // Append the paragraph to the message div
    messageDiv.appendChild(paragraph);

    // Create the timestamp span element
    const timestampSpan = document.createElement('span');
    timestampSpan.classList.add('text-xs', 'text-gray-500', 'leading-none');
    var currentDateUTC = new Date();

    timestampSpan.textContent = `${currentDateUTC.getDate()}`;

    // Append the message div and timestamp span to the first child div
    messageDiv.appendChild(timestampSpan);

    // Create the second child div
    const avatarDiv = document.createElement('div');
    avatarDiv.classList.add('flex-shrink-0', 'h-10', 'w-10', 'rounded-full', 'bg-gray-300');

    // Append the first and second child divs to the outermost div
    outerDiv.appendChild(messageDiv);
    outerDiv.appendChild(avatarDiv);


    document.getElementById("messagesList").appendChild(outerDiv);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you
    // should be aware of possible script injection concerns.
    // outerDiv.textContent = `${user} says ${message}`;
});