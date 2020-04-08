# eintech-test

Hi there, thanks for taking the time to review this!
As I explained to my recruiter I've been doing 100% backend engineering in the past 3+ years. Because of this, I'm not sure how much can be determined about how I write code/engineer a system in general - I'm a bit out of my depth.
I used the latest Rider on Ubuntu 16.04 to build this. All projects were built with the latest .NET Core LTS.
(Inititally I tried building it on my Windows VM during Sunday, but something got messed up, and I couldn't run any .net core projects on it anymore. Luckily Rider runs on Linux too, so I didn't need to create a new VM...)

## Testing
I've tested this on Chrome.
To be able to run the Acceptance tests, place the chromedriver.exe in the Acceptance Test root. (If you run the tests without it, the exception will give you a link from which you can download it.)

## Notes
- I tend to build my backend apps in one project. I believe if the code is architectured correctly, responsibilities are sufficiently separated, then it should be easy to split the project by layer into multiple projects when it delivers value. Value could be for example if the same data/business layer can or needs to be reused in different apps, or the presentation layer needs to be swapped out. If there is no use case to make the layers function without each other, then splitting the app falls under YAGNI, in my opinion. But as stated earlier, I'm kind of new to full stack development, so I know I can be wrong.
- I did break out the Data layer as you can see - mainly to reuse it in the database seed project.
- I've built the frontend part first, with just dummy data behind. The reason for this is that I like to begin with an (end-to-end) acceptance test, that tests the functionality from the end user's perspective. Building the backend part (either the data access layer, or some merged data/bl layer that can be refactored into 2 later) wouldn't let me test what the user would see, so I would've ended up adding the e2e test later.
- I used Selenium and Cucumber in the past to write some e2e tests. (For example when our APIs need to talk to PayPal.) Here I picked Selenium, I think it's much more suited for this task.
- "Create at least 2 groups and 5 people, this is to be completed as an MVC application." - if I understand correctly, this means you don't want me to create and fill the db with a sql script, and then use that from the app, but rather you want to see how I create and fill a db from code. Hence the reason for the database seed app.
- "We need to search for people in the database, either by name, part of name, or by group." - this was a bit vague to me. (Under normal circumstances I'd sit down with the stakeholders and refine the requirements. :) ) I interpreted this as there needs to be one search box, and when the user starts searching, they should see results from both people and groups. The "either by name, part of name" seemed redundant - if we search by part of the name, that function does search for the whole name too if the search term is coincidentally the whole name of someone.
- Since I use TDD all the time and I develop WebApi solutions, I dockerise my apps all the time to ensure my testing environment matches the runtime environment in the wild. Here, I wasn't sure how to do it, since the test environment would've needed a browser to be deployed to it.
- I felt a bit uneasy about not using DTOs on the Model level, but since the data layer consists of POCO classes, I think DRY takes precendence until there is a need to differentiate between objects in the two layers.
