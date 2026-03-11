# ADR 001: Use JSON for Local Storage

**Date:** 2026-03-11
**Status:** Accepted

## Context
Argos requires a fast, lightweight, and reliable way to store task states and user data locally. Implementing a full relational database (like SQL Server) or a NoSQL engine (like MongoDB) in the early stages of Module 1 introduces unnecessary overhead, increases the application footprint, and complicates local deployment for new users.

## Decision
We decided to use raw **JSON serialization** (via `System.Text.Json`) targeting a local file (`tarefas.json`) as the primary data persistence mechanism for Module 1.

## Consequences
* **Positive:** Zero configuration required for the user. Extremely fast read/write for small datasets. Easy to debug by simply opening the file in a text editor.
* **Positive:** Aligns with the "Privacy First" core principle, keeping data entirely on the user's machine without external database connections.
* **Negative:** Not scalable for massive datasets or complex relational queries (which will be addressed when Module 2/OSINT scales up and requires SQLite or MongoDB).