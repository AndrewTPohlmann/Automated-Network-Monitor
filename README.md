# WOPU
**Web-Oriented Ping Utility with Data Persistence and Visualization**

The goal of this project is to gather and persist ping data (RTT times / %Loss), and then transform this data into visual projections for the purposes of analysis.

**Architectural Requirements:**
Design and implementation of a system that uses the MVC architectural pattern to present a front-end UI, process data, and persist the data in a database in the back-end.

**System Use Cases:**
- Create and begin ping jobs, or delete currently running jobs.
- Create visual projections in the GUI based on persisted data sets from the back-end.
- Allow some CRUD operations against the back-end DB datasets.

**TODO List**:
- Port txtFile data into BSON document sets
- Implement MongoDB backend connectivity to persist the data documents
- Implement UI controls to maintain the data document sets and load sets into the graph
-
