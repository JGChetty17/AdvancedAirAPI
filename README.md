# AdvancedAirAPI — HVAC Website Backend

A RESTful backend API built with [ASP.NET Core 8](https://asp.net/) and Entity Framework Core, powering the Advanced Air Conditioning website.

The API manages product catalogues, service listings, customer enquiries, urgent callout requests, and multi-room quotation submissions. It connects to a Supabase PostgreSQL database and is deployed on Render using Docker.

---

## Group Member

| Student Number | Name |
|:---|:---|
| ST10439133 | Camryn Naidoo |
| ST10441399 | Suvan Samlall |
| ST10451026 | Calib Frank |
| ST10446908 | Caleb Ragaven |
| ST10296234 | Joshua Chetty |
| ST10451537 | Keshvir Parthab |

---

## Final POE Links

| Deliverable | Link |
|:---|:---|
| **Website GitHub Repository** | [HvacWebsite](https://github.com/ST10441359/HvacWebsite.git) |
| **Website API GitHub Repository** | [AdvancedAirAPI](https://github.com/ST10441359/AdvancedAirAPI.git) |
| **Website API Hosted Link** | [AdvancedAirAPI – Render](https://advancedairapi.onrender.com) |

---

## About

AdvancedAirAPI is the backend service powering the Advanced Air Conditioning website. It exposes a collection of RESTful endpoints consumed by the React frontend, providing product catalogues, service descriptions, and customer submission handling.

The API supports various customer interactions, including general contact enquiries, urgent service callouts, and detailed multi-room quotation requests.

The application is developed using **ASP.NET Core 8**, with **Entity Framework Core** and **Npgsql** handling communication with a **Supabase PostgreSQL** database. The application is containerised using Docker and deployed on Render.

---

## The Problem It Solves

HVAC businesses require an efficient way to receive and manage customer enquiries online. However, many existing solutions are either expensive or too generic to accommodate specific business requirements.

AdvancedAirAPI addresses these challenges by providing:

- A centralised API for website data and customer form submissions.
- A structured quotation system that captures customer details and multiple rooms within a single request.
- A dedicated urgent callout workflow for emergency service requests.
- A clear separation between the public-facing website and the backend data layer.

The API is designed to be lightweight, maintainable, and cost-effective, making it suitable for small businesses and demonstration environments.

---

## Key Features

### 1. Products

- Read-only catalogue of available HVAC units.
- Includes product name, brand, model, BTU, price, description, rating, image, coverage area, and features.
- Retrieves product information from the `products` table in Supabase.

### 2. Services

- Provides a catalogue of services offered by the business.
- Each service includes an icon name, title, description, and bullet points.
- Retrieves service information from the `services` table.

### 3. Contact Messages

- Accepts general customer enquiries through the website contact form.
- Captures the customer's full name, email address, phone number, subject, and message.
- Stores submissions in the `contact_messages` table.

### 4. Callout Requests

- Provides a dedicated endpoint for urgent service requests.
- Captures customer details, urgency level, property address, issue description, preferred contact method, and preferred visit time.
- Stores submissions in the `callout_requests` table.

### 5. Quote Requests

- Handles detailed quotation requests containing customer information and one or more rooms.
- Saves the parent quotation record with customer details, urgency, service type, preferred date, and additional information.
- Inserts associated room records into the `quote_rooms` table.
- Includes null validation to prevent server errors when no rooms are submitted, returning an HTTP `400 Bad Request` response with a validation message instead.

### 6. Health Check

- Provides a `/health` endpoint that returns the API status, timestamp, and environment name.
- Integrated with UptimeRobot to help keep the API responsive on Render's free tier.

### 7. CORS Configuration

- Configurable allowed origins through an environment variable.
- Restricts cross-origin requests to authorised domains.
- Requires an exact origin match, without a trailing slash.

---

## Architecture

The API follows a **layered architecture**, promoting separation of concerns, maintainability, and organisation.

| Layer | Responsibility |
|:---|:---|
| **Controllers** | Handle incoming HTTP requests and generate appropriate responses. |
| **Services** | Contain business logic and handle data access operations. |
| **Data** | Contains `AppDbContext` and Entity Framework Core database mappings. |
| **Models** | Define entity classes representing the database tables. |

### Application Configuration

The `Program.cs` file is responsible for configuring the application and its services, including:

- Database connectivity and Entity Framework Core.
- Dependency injection and service registration.
- Cross-Origin Resource Sharing (CORS).
- Swagger API documentation.
- Health check endpoint mapping.

**Deployment Configuration:** HTTPS redirection is intentionally disabled within the application because Render terminates HTTPS/TLS connections at its reverse proxy. The application handles the forwarded requests through Render's infrastructure.

---

## Technology Stack

| Technology | Purpose |
|:---|:---|
| ASP.NET Core 8 | Backend Web API framework |
| C# | Backend programming language |
| Entity Framework Core | Object-relational mapping (ORM) |
| Npgsql | PostgreSQL database provider |
| Supabase PostgreSQL | Cloud-hosted relational database |
| Docker | Application containerisation |
| Render | API hosting and deployment |
| Swagger / OpenAPI | API documentation and testing |
| UptimeRobot | API availability monitoring |

---

## Hosting

The API is hosted on Render using a Docker container, with Supabase providing the PostgreSQL database.

**Live API:** [https://advancedairapi.onrender.com](https://advancedairapi.onrender.com)

**Health Check:** [https://advancedairapi.onrender.com/health](https://advancedairapi.onrender.com/health)

---

## Repository

**GitHub:** [https://github.com/JGChetty17/AdvancedAirAPI.git](https://github.com/JGChetty17/AdvancedAirAPI.git)
