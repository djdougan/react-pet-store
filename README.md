
create migrations

dotnet ef migrations add "InitialCreate" -p Infrastructure -s API -o Identity/Migrations -c StoreContext

view api: 
https://localhost:5001/swagger/index.html

  npm start
    Starts the development server.

  npm run build


    Bundles the app into static files for production.

  npm test
    Starts the test runner.

  npm run eject
    Removes this tool and copies build dependencies, configuration files
    and scripts into the app directory. If you do this, you can’t go back!

We suggest that you begin by typing:

  cd client
  npm start


