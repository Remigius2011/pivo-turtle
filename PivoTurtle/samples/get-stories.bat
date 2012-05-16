SET TOKEN=%1
SET TOKEN=c811ad969733b4227a32a39775e310be
SET PROJECT_ID=114811
SET STORY_ID=5165684
rem curl -H "X-TrackerToken: %TOKEN%" -X GET "https://www.pivotaltracker.com/services/v3/projects/%PROJECT_ID%/stories?filter=mywork%3Aremigius%20status%3Astarted" > stories.xml
curl -H "X-TrackerToken: %TOKEN%" -X GET "https://www.pivotaltracker.com/services/v3/projects/%PROJECT_ID%/stories?filter=status:started" > stories.xml
rem curl -H "X-TrackerToken: %TOKEN%" -X GET "https://www.pivotaltracker.com/services/v3/projects/%PROJECT_ID%/stories?filter=mywork%3Aremigius" > stories.xml

curl -H "X-TrackerToken: %TOKEN%" -X GET https://www.pivotaltracker.com/services/v3/projects/%PROJECT_ID%/stories/%STORY_ID%/tasks > tasks.xml

pause
