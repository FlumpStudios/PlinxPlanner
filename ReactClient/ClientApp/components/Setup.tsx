import * as React from "react";
import { Image, Header } from "semantic-ui-react";

class Setup extends React.Component {
  state = {};
  render() {
    return (
      <div>
        <Header as="h3">Setup Steps</Header>

        <p>
          If you've got this far, you have probably worked out most of the
          following points. Anyway, here are the steps to get the Solution
          running on your machine
        </p>
        <ol>
          <li>
            {" "}
            <strong>Ensure the .Net core 2.2 SDK is installed.</strong> This
            solutions was created using the latest (at the time) version of .NET
            core. If you have not installed the latest SDK you can download them
            from{" "}
            <a target="_blank" href="https://dotnet.microsoft.com/download">
              here
            </a>{" "}
          </li>
          <li>
            <strong>Ensure the Node packages are up-to-date.</strong> The
            easiest way to do this is to restore the packages through visual
            studio.
          </li>
          <ul>
            <li>Expand the Dependencies on your react client</li>
            <li>Right click and select 'Restore Packages'</li>
            <li>Wait for packages to restore and check terminal for errors.</li>
          </ul>
          <Image
            style={{
              marginLeft: "30px",
              marginBottom: "10px",
              height: "175px"
            }}
            src={require("../content/images/RestorePackages.jpg")}
          />
          <ul>
            <em>
              If you have any problems restoring the packages in this manner,
              try updating and installing the NPM packages through a command
              prompt. To do this, follow these steps...
            </em>
            <li>Open a command prompt on the client app location.</li>
            <li>
              Type <code>NPM update</code>
            </li>
            <li>
              Wait for update to complete then type <code>NPM Install</code>
            </li>
          </ul>
          <li>
            {" "}
            <strong>Setup your connection string.</strong> By default, the
            solution scaffolds the DB to a localDB. If you do not have a localDB
            instance, you will need to update the DB connection string in the
            appsettings of the Demo.API project and the Identity.Admin project{" "}
          </li>
          <li>
            {" "}
            <strong>
              Build the solution to check all is going smoothly.{" "}
            </strong>{" "}
          </li>
          <li>
            {" "}
            <strong>Update the API database.</strong> To do this, follow these
            steps .
            <ul>
              <li>
                Open the package manager console. This can me found on the
                visual studio menu here - Tools/NuGet Package Manager/Package
                manager console
              </li>
              <li>
                In the package manager console, set your default project to
                'Demo.Context'
              </li>
              <li>
                Then type{" "}
                <code> Update-Database -context AP_ReplacementContext</code>{" "}
                into your package manager console. This will scaffold you a
                database and seed the db with some test data
              </li>
            </ul>
          </li>
          <li>
            <strong>Setup the correct startup projects.</strong> In the solution
            properties set the start up projects to run Demo.API,
            Identity.Admin, Identity.STS.Identity and ReactClient{" "}
          </li>
          <li>
            {" "}
            <strong>
              Make sure the projects are running on the correct ports.
            </strong>{" "}
            Each project needs to be running on the following ports.
            <ul>
              <li>Identity.STS.Identity = http://localhost:5000</li>
              <li>ReactCient = http://localhost:5100</li>
              <li>Demo.API = http://localhost:5200</li>
              <li>Identity.Admin = http://localhost:9000/</li>
            </ul>
            <p>
              <em>
                The debug ports are selected in the debug section of the
                projects properties.
              </em>
            </p>
            <Image
              style={{
                marginLeft: "30px",
                marginBottom: "10px",
                height: "175px"
              }}
              src={require("../content/images/DebugUrl.jpg")}
            />
          </li>
          <li>
            {" "}
            <strong>Rebuild and run the project</strong>
          </li>
          <li>
            {" "}
            <strong>Log into Identity Server </strong>You can login to the
            identity server with the following credentials
            <ul>
              <li>AdminUserName = "admin"</li>
              <li>AdminPassword = "Pa$$word123";</li>
            </ul>
            <p>
              Note:
              <em>
                {" "}
                To test the endpoints in swagger you must Authorise first. You
                can do this first by clicking the 'Authorize' button at the top
                of the swagger page. Make sure you tick the 'DealLogApi' box
                under the scopes section, otherwise you will receive an 'Invalid
                scope' error{" "}
              </em>
            </p>
          </li>
          <li>
            In order to allow the front-end Role to permission mapping, make
            sure that the 'Role' user claim is included in the profile Identity
            resource on the Listers Identity admin area.
          </li>
        </ol>
        <p>That's it...you should now be all good to go!</p>
      </div>
    );
  }
}

export default Setup;
