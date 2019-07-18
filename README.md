# .NET CORE 2.2 solution Boilerplate
<h3>Info</h3>
<p>
  This branch serves as a boilerplate solution which can be used a jumping off point for creating a new .NET core API project. 
</p>
<p>  
  This project includes Swagger intergration, Code first EF with seeding, controller to service mapping,  STS/SSO with ID server 4, ID Admin area with Skoruba, unit testing, memcaching, AES 256 Encryption and logging to db with NLOG. The solution also contains a react client with Typescript, Redux, Semantic-UI, Routing, Open ID connect, Axios and role to permission mapping. 
</p>             
<h3>Setup Steps</h3> 
        <ol>
          <li>         
            <strong>Ensure the .Net core 2.2 SDK is installed.</strong> This
            solutions was created using the latest (at the time) version of .NET
            core. If you have not installed the latest SDK you can download them
            from
            <a target="_blank" href="https://dotnet.microsoft.com/download">
              here
            </a>
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
            <strong>Setup your connection string.</strong> By default, the
            solution scaffolds the DB to a localDB. If you do not have a localDB
            instance, you will need to update the DB connection string in the
            appsettings of the Demo.API project and the Identity.Admin project
          </li>
          <li>
            <strong>
              Build the solution to check all is going smoothly.
            </strong>
          </li>
          <li>            
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
                <code> Update-Database -context AP_ReplacementContext</code>
                into your package manager console. This will scaffold you a
                database and seed the db with some test data
              </li>
            </ul>
          </li>
          <li>
            <strong>Setup the correct startup projects.</strong> In the solution
            properties set the start up projects to run Demo.API,
            Identity.Admin, Identity.STS.Identity and ReactClient
          </li>
          <li>        
            <strong>
              Make sure the projects are running on the correct ports.
            </strong>
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
          </li>
          <li>      
            <strong>Rebuild and run the project</strong>
          </li>
          <li>       
            <strong>Log into Identity Server </strong>You can login to the
            identity server with the following credentials
            <ul>
              <li>AdminUserName = "admin"</li>
              <li>AdminPassword = "Pa$$word123";</li>
            </ul>
            <p>
              Note:
              <em>            
                To test the endpoints in swagger you must Authorise first. You
                can do this first by clicking the 'Authorize' button at the top
                of the swagger page. Make sure you tick the 'DealLogApi' box
                under the scopes section, otherwise you will receive an 'Invalid
                scope' error
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
        <p>This is just to get you up and running. Run the react client for further information and details.</p>
      </div>      
  
<h3>Troubleshooting</h3>
<strong>'CSC' error</strong>
<p>
If you have updated your NPM packages and you're still seeing a CSC error, try installing the latest version of the Microsoft.Net.Compilers from nuget on the identity and identity.admin projects.
</p>
<strong>500 error Visual Studio popup</strong>
<p>
If when trying to run the Identity.Admin project you see a visual studio popup with a 500 error, ensure the asp core module is set as 'AspNetCoreModule' and not 'AspNetCoreModuleV2' in the identity.admin web.config
</p>
<strong>Module build failed (from ./node_modules/sass-loader/lib/loader.js)</strong>
<p>
If when running the react client you are greated with the following error:
<code>
Module build failed (from ./node_modules/sass-loader/lib/loader.js):
Error: ENOENT: no such file or directory, scandir 'E:\Dev\deal-log\ReactClient\node_modules\node-sass\vendor'
 </code>
 <br/>
 You just need to install the latest version of node sass through NPM.
 Just run <code>npm installnode-sass</code> through the command line in the clientApp folder of the reactclient project.
 </p>
 <p>
 <strong>Unable to launch the previously selected debugger. Please choose another.</strong>
</p>
<p>
 First try rebuilding the project and re-running. If that doesn't work, try restarting visual studio, rebuilding and re-runiing. If there's still no luck, deleting your .vs file should fix the problem.
This is a known bug with VS2017 unfortunately.
 </p>

