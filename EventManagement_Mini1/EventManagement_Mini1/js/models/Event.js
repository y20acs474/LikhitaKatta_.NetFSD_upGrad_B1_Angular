export default class Event {
    constructor(id, title, description, date, location, capacity, availableSeats) {
        this.id = id
        this.title = title
        this.description = description
        this.date = date
        this.location = location
        this.capacity = capacity
        this.availableSeats = availableSeats
    }

    validate() {
        if (!this.title || !this.location) {
            throw new Error("Title and location are required")
        }

        const today = new Date()
        const eventDate = new Date(this.date)

        if (eventDate < today) {
            throw new Error("Date cannot be in the past")
        }

        if (this.capacity <= 0) {
            throw new Error("Capacity must be positive")
        }
    }
}