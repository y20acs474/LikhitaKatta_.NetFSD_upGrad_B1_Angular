import { addRegistration, getEvents, updateEvent } from "../services/apiService.js";

const form = document.getElementById("registerForm");
const eventTitle = document.getElementById("eventTitle");

// get eventId from URL
const params = new URLSearchParams(window.location.search);
const eventId = params.get("eventId");

let selectedEvent = null;

// load event details
async function loadEvent() {
  const events = await getEvents();

  selectedEvent = events.find(e => String(e.id) === String(eventId));

  if (selectedEvent) {
    eventTitle.textContent = "Event: " + selectedEvent.title;
  } else {
    eventTitle.textContent = "Event not found";
  }
}

loadEvent();

form.addEventListener("submit", async (e) => {
  e.preventDefault();

  if (!selectedEvent) {
    alert("Event not found");
    return;
  }

  if (selectedEvent.availableSeats <= 0) {
    alert("No seats available");
    return;
  }

  const name = document.getElementById("name").value;
  const email = document.getElementById("email").value;
  const phone = document.getElementById("phone").value;

  const registration = {
    eventId: selectedEvent.id,
    participantName: name,
    email: email,
    phone: phone
  };

  // save registration
  await addRegistration(registration);

  // reduce seats
  const updatedEvent = {
    ...selectedEvent,
    availableSeats: selectedEvent.availableSeats - 1
  };

  await updateEvent(selectedEvent.id, updatedEvent);

  alert("Registration successful");

  form.reset();
});