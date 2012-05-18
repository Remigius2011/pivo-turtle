SET TOKEN=%1
SET TOKEN=c811ad969733b4227a32a39775e310be
SET PROJECT_ID=114811
SET STORY_ID=5165684
rem NOTE: in actual code, the percent sign is requred only once. here the percent has to be excaped as %% because it's in a batch file
rem curl -H "X-TrackerToken: %TOKEN%" -X GET https://www.pivotaltracker.com/services/v3/projects/%PROJECT_ID%/stories > all-stories.xml
curl -H "X-TrackerToken: %TOKEN%" -X GET "https://www.pivotaltracker.com/services/v3/projects/%PROJECT_ID%/stories?filter=mywork:remigius%%20state:started" > stories.xml
rem curl -H "X-TrackerToken: %TOKEN%" -X GET "https://www.pivotaltracker.com/services/v3/projects/%PROJECT_ID%/stories?filter=state:started" > stories-starter.xml
rem curl -H "X-TrackerToken: %TOKEN%" -X GET "https://www.pivotaltracker.com/services/v3/projects/%PROJECT_ID%/stories?filter=mywork:remigius" > stories-remigius.xml
rem curl -H "X-TrackerToken: %TOKEN%" -X GET "https://www.pivotaltracker.com/services/v3/projects/%PROJECT_ID%/stories?filter=label%3A%22client%22%20type%3Abug" > stories.xml


rem curl -H "X-TrackerToken: %TOKEN%" -X GET https://www.pivotaltracker.com/services/v3/projects/%PROJECT_ID%/stories/%STORY_ID%/tasks > tasks.xml

pause
