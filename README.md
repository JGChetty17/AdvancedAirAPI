# Advanced Air API

Backend for the Advanced Air Conditioning website — a public-facing marketing and
catalogue site that reads product and service data from Supabase and stores form
submissions (contact, callout, quote requests).

Built with **ASP.NET Core Web API** + **Entity Framework Core** + **Npgsql**,
connecting to a **Supabase PostgreSQL** database.

---

## Overview

The API is a classic three-tier backend. It sits between the React frontend and
Supabase:

- The React frontend calls REST endpoints (`/api/products`, `/api/services`, etc.).
- The API queries PostgreSQL via EF Core and returns JSON.
- Form submissions (contact, callout, quote) are written to Supabase.

No login or authentication is required — the website is public and read-mostly.

---

## Tech Stack

| Layer | Technology |
| --- | --- |
| Framework | ASP.NET Core Web API (.NET 8) |
| ORM | Entity Framework Core |
| Database | Supabase (PostgreSQL) |
| DB driver | Npgsql.EntityFrameworkCore.PostgreSQL |
| API docs | Swagger / OpenAPI |
| Frontend | React (separate project) |

---

## Project Structure
