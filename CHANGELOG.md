# Changelog

All notable changes to the **Argos** project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]
### Added
- Dynamic color-coding for category tags in the UI (e.g., `#osint` in red, `#dev` in green). *[Currently in development branch]*

## [0.1.0] - 2026-03-11
### Added
- **Core Engine:** Base Avalonia UI setup with custom borderless window design (Hacker/Terminal aesthetic).
- **Task Management:** Ability to add tasks and mark them as completed.
- **Data Persistence:** Local JSON serialization/deserialization to save state between sessions.
- **Real-Time Filtering:** Integrated LINQ query system for instant search and filtering by category.
- **Telemetry/Metrics:** Live dashboard displaying pending and completed task counts.
- **Hashtag Parsing:** Automated extraction of categories using inline `#` syntax.

### Security & Privacy
- Zero telemetry. All data is written exclusively to local `tarefas.json`.