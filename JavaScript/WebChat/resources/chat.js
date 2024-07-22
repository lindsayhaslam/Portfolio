"use strict";

//Set parts of the document into variables
//TOP HALF
const usernameInput = document.getElementById('myname');
const roomInput = document.getElementById('room');
const joinButton = document.getElementById('joinButton');
//BOTTOM HALF
const messageInput = document.getElementById('messagehere');
const sendMessageButton = document.getElementById('sendButton');
//Leave button
let leaveButton = document.getElementById('leave');
leaveButton.onclick = handleClose;

//Server
const serverURL = "ws://localhost:8080/";
let ws = new WebSocket(serverURL);
let wsOpen = false;

//Webserver actions
ws.onopen = handleOpen;
ws.onmessage = handleMsg;
ws.onclose = handleClose;


// Function to join a room
function joinRoom(username, roomName) {
  if (wsOpen) {
  const joinMessage = `join ${username} ${roomName}`;
    ws.send(joinMessage);
    console.log("Attempted to join!");
  }
}
 // Event listener for the "Join" button
 joinButton.addEventListener('click', function () {
    const username = usernameInput.value;
    const roomName = roomInput.value;
    //Filter for invalid roomName inputs
    if (username && roomName) {
       if (roomName >= 'a' && roomName <= 'z') {
       joinRoom(username, roomName);
       console.log("Joined!")
       }
       else {
       alert("Your room-name must contain only lowercase letters.");
      }
     }
  });

  function sendMessage(message) {
    if (wsOpen) {
      const chatMessage = JSON.stringify({ type: 'message', message });
      ws.send(message);
      console.log(message);
    }
  }
  // Event listener for the "Send" button
  sendMessageButton.addEventListener('click', function () {
        sendMessage(messageInput.value);
        console.log("message " +messageInput.value);
        messageInput.value = '';
  });

//Parse message and check type
  function handleMsg(event) {
    let message = event.data;
    let msg = JSON.parse(message)
    if(msg.type == "message"){
        displayMessage(msg.message);
    }
    else if (msg.type == "join"){
          const messageToDisplay = `${msg.user} has joined room ${msg.room}!`;
          displayPeopleMessage(messageToDisplay);
    }
  }
//For displaying the users who appear in the room in the correct box
    function displayPeopleMessage(users) {
      const messageDiv = document.createElement('p');
      messageDiv.textContent = users;
      people.appendChild(messageDiv);
      // Automatically scroll to the latest message
      people.scrollTop = people.scrollHeight;
    }
//For displaying the messages sent in the correct box
  function displayMessage(message) {
    const messageDiv = document.createElement('div');
    messageDiv.textContent = message;
    messageArea.appendChild(messageDiv);
    // Automatically scroll to the latest message
    messageArea.scrollTop = messageArea.scrollHeight;
  }

//Switch wsOpen to true
function handleOpen(event){
    wsOpen = true;
    console.log(event);
}

//Send a message when you leave the room
function handleClose(event){
    let you = document.createTextNode("You left the room.");
    let lineBreak = document.createElement("br");
    messageArea.appendChild(lineBreak);
    messageArea.appendChild(you);
    ws.send("leave");
}

