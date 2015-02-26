# WOPU
**Web-Oriented Ping Utility with Data Persistence and Visualization**

The goal of this project is to gather and persist ping data (RTT times / %Loss), and then transform this data into visual projections for the purposes of analysis.

**Architectural Requirements:**
Design and implementation of a system that uses the MVC architectural pattern to present a front-end UI, process data, and persist the data in a NoSQL database in the back-end.

**System Use Cases:**
- Create and begin ping jobs, or delete currently running jobs.
- Create visual projections in the GUI based on persisted data sets from the back-end.
- Allow some CRUD operations against the back-end DB datasets.

**Currently being rapid-prototyped in C#.**

**Will be ported to:**
Angular.js on the front-end;
Node.js on the back-end;
MongoDB for data persistence;
JSON for data;
....all using HTML5/JS.


