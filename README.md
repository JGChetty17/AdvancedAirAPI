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

## References
ASP.NET Core Web API — Official Docs. Retrieved from https://learn.microsoft.com/aspnet/core/web-api/

Axios HTTP Client — Official Docs. Retrieved from https://axios-http.com/docs/intro

CORS (Cross-Origin Resource Sharing) — MDN Web Docs. Retrieved from https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS

Entity Framework Core — Official Docs. Retrieved from https://learn.microsoft.com/ef/core/

GeeksforGeeks. ASP.NET Core Web API — Introduction. Retrieved from https://www.geeksforgeeks.org/asp-net-core-web-api/

GeeksforGeeks. Three-Tier Architecture. Retrieved from https://www.geeksforgeeks.org/three-tier-architecture/

Npgsql — Entity Framework Core Provider. Retrieved from https://www.npgsql.org/efcore/

PostgreSQL Official Documentation. Retrieved from https://www.postgresql.org/docs/

Supabase Documentation. Retrieved from https://supabase.com/docs

Supabase. Connection Pooling Guide. Retrieved from https://supabase.com/docs/guides/database/connecting-to-postgres#connection-pooler

W3Schools. SQL Tutorial. Retrieved from https://www.w3schools.com/sql/

W3Schools. RESTful Web Services. Retrieved from https://www.w3schools.com/rest/
