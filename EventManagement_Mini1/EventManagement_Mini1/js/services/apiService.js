const BASE_URL = "http://localhost:3000/events";

// GET EVENTS
export async function getEvents() {
  const res = await fetch(BASE_URL);
  return res.json();
}

// ADD EVENT
export async function addEvent(event) {
  const res = await fetch(BASE_URL, {
    method: "POST",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify(event)
  });

  return res.json();
}

// DELETE EVENT
export async function deleteEvent(id) {
  await fetch(`${BASE_URL}/${id}`, {
    method: "DELETE"
  });
}

// UPDATE EVENT (THIS IS NEEDED FOR SEAT REDUCTION)
export async function updateEvent(id, eventData) {
  await fetch(`${BASE_URL}/${id}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify(eventData)
  });
}

// ADD REGISTRATION
export async function addRegistration(registration) {
  await fetch("http://localhost:3000/registrations", {
    method: "POST",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify(registration)
  });
}