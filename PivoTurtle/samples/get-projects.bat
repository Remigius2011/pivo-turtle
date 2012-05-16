SET TOKEN=%1
SET TOKEN=c811ad969733b4227a32a39775e310be
curl -H "X-TrackerToken: %TOKEN%" -X GET https://www.pivotaltracker.com/services/v3/projects > projects.xml
pause
