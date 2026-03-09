export default class Registration {
    constructor(id, eventId, participantName, email, phone) {
        this.id = id
        this.eventId = eventId
        this.participantName = participantName
        this.email = email
        this.phone = phone
    }

    validate() {

        if (!this.participantName) {
            throw new Error("Name required")
        }

        const emailRegex = /\S+@\S+\.\S+/
        if (!emailRegex.test(this.email)) {
            throw new Error("Invalid email")
        }

        const phoneRegex = /^[0-9]{10}$/
        if (!phoneRegex.test(this.phone)) {
            throw new Error("Phone must be 10 digits")
        }
    }
}