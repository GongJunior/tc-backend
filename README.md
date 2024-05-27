# Description
Sample backend assignment from a Tim Corey video.
- https://www.youtube.com/watch?v=BbxjvV3d9pY

## Notes
- run db for migrations: docker run -d --rm -p 5000:5432 -e POSTGRES_PASSWORD=mysecret -v .\db\data:/var/lib/postgresql/data postgres
- run app: docker compose up -d
- explore endpoints: http://localhost:5067/swagger/

## GPT Requirements
- Build a system to capture purchase data from a caller and store it in a database.
- Ensure that if there's a duplicate user, update their data instead of adding a new record.
- The system should be flexible enough to accommodate different methods of capturing data (e.g., API, class library).
- Use C# for implementation, but the specific project type (e.g., class library, API) is up to you.
- Choose the type of database you prefer (e.g., NoSQL like MongoDB or Cosmos, SQL like SQL Server, SQLite, MySQL).
- Test the system thoroughly for functionality, including handling data input errors, wrong information, and duplicate entries.
- Emphasize functional correctness over aesthetics (since there's no UI required).
- Consider incorporating features like logging, dependency injection, or other structural elements to showcase your skills as a back-end developer.
    ### Example
        Let's say I purchase a book; you take the information and store it in the database: "Tim purchased a book." Then let's say that Sue purchases a t-shirt; so you put that information in the database as a new record: "Sue purchased a t-shirt." Now, let's say I purchased a t-shirt; so you'd say, "Okay, well, Tim already has a record in the database, so let's just add 'purchased a t-shirt' into Tim's record or in some way associate it with my existing record. That way, you don't have two different entries for Tim in the database."

## GPT Formatted Transcript
On Thursday, in a Dev question video, I answered the question: what is a back-end developer and what do they do. Yesterday, I showed you how to become a back-end developer with C#, and today it's time to challenge your skills in back-end development with C#. Whether you've been using C# for a long time or just started working with it, this challenge should teach you something about where your skills are at and what you still need to work on. So let's jump right into the challenge.

The challenge is to build a system to capture purchase data from a caller, store the data in a database. Now, I'll pause right here; this is vague wording because, again, I have tried to keep this as open as possible. You could be building an API or you could be playing a class Library; it's up to you how you want to capture this purchase data from a caller.

So, build a system to capture purchase data from a caller, store the data in a database. If there's a duplicate user, update their data instead of adding a new record.

Let's say I purchase a book; you take the information and store it in the database: "Tim purchased a book." Then let's say that Sue purchases a t-shirt; so you put that information in the database as a new record: "Sue purchased a t-shirt."

Now, let's say I purchased a t-shirt; so you'd say, "Okay, well, Tim already has a record in the database, so let's just add 'purchased a t-shirt' into Tim's record or in some way associate it with my existing record. That way, you don't have two different entries for Tim in the database."

That's your goal for building a system. Again, it's up to you how you build it and what part of C# you build it in, what type of project you use; whether it's a class Library, that's great. But you might want to write some unit tests or something to verify that it actually works, or an API, and maybe write the HTTP file to test your API, or whatever you decide for how you're going to capture purchase data from the caller. And that caller, you're going to make up the purchase that it's sending in, but I want you to store this in a database.

And again, which database? Up to you. Do you want a NoSQL database like MongoDB or Cosmos? Cool. Do you want a SQL database like SQL Server or SQLite or MySQL? Cool, go for it. Up to you.

You choose what you want to do, all right? So it's up to you, but I want you to take on this challenge. And as I said before, it's important that you put the effort in to get this challenge done, rather than just wait until Friday when I release my solution video. Because just watching a solution video is going to give you a kind of a warm fuzzy feeling of, "Oh, I understand this now, probably," but that's not really the way to get the most information out of this process. The way to get the most information out is for you to do it first yourself, even if that means holding off and watching a solution video until after you've really figured out how to make this work and have written your own application.

Now, this one doesn't have to be pretty because there's no UI, but this one does have to be functionally correct, meaning I will make sure that you're thinking through things like data input errors or information that is wrong, or checking that the duplicates come in and not as duplicates, and all other information that could go wrong. Make sure you test for it in your final product, make sure it's actually going to work and not just for the easy stuff. Make sure that you throw some curveballs at it and make sure it still stands up and it still works correctly, okay?

The way you do it is up to you, but you really need to show off your skills as a back-end developer here. So, you can do a lot of different things with logging or dependency injection or the way you structure your application or how it's built, whatever you want to do. But think through how you want to build this to best show off what you can do as a back-end developer, all right?

Get to it.