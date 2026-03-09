import { getEvents } from "../services/apiService.js"

const eventList = document.getElementById("eventList")

export const loadEvents = async () => {

    const events = await getEvents()

    eventList.innerHTML = ""

    events.forEach(event => {

        const div = document.createElement("div")

        div.innerHTML = `
<h3>${event.title}</h3>
<p>${event.description}</p>
<p>Date: ${event.date}</p>
<p>Location: ${event.location}</p>
<p>Seats Available: ${event.availableSeats}</p>

<a href="register.html?eventId=${event.id}">
<button>Register</button>
</a>

<hr>
`

        eventList.appendChild(div)

    })
}