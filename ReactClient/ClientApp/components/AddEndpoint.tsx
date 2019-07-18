import * as React from "react";
import { Header } from "semantic-ui-react";
import { NavLink, Link } from "react-router-dom";
class AddEndPoint extends React.Component {
  state = {};
  render() {
    return (
      <div>
        <Header as="h3">How to add an endpoint - quick guide</Header>
        <p>
          This guide will run through how to add a new endpoint to your API, we
          will be adding a simple GET request pipeline to the API. This is
          intended as a quick guide and if there's anything that doesn't quite
          make sense, check out some of the articles in the{" "}
          <Link to="SuggestReading">Suggested reading and tutorials</Link> area.
        </p>
        <Header as="h4">Part 1 - Add a new repository</Header>
        <p>
          When adding a new endpoint, you're going to need some data to parse
          and present to the client, so the first thing you're going to want to
          do is to create your repo to retrieve the data from your data source.
          Follows these steps to create and setup your repo.
          <ol>
            <li>
              Right click on you <code>Demo.DataAccess.EntityFramework</code>{" "}
              project and add a new class. Make sure the access modifier is set
              to public.
            </li>
            <li>
              Now we need to add a method to query the data source. For this
              purpose, we'll keep it light and easy. Add the following expression
              to your new class <br />{" "}
              <code>
                {" "}
                public async Task&lt;IEnumerable&lt;<em>YourClassName</em>
                &gt; GetSomeData() => await _context.<em>YourClassName</em>
                .ToListAsync();{" "}
              </code>{" "}
              <br /> This will bring back a list of all the data in the
              'YourClassName' DBSet
            </li>
            <li>
              Now we need to extract an interface from the new class which we
              will later register with the IOC. The quickest way to do this is
              to highlight your class name, then press CTRL+. which will bring
              up the Quick Actions menu. Then select 'Extract Interface'. This
              will create an interface for you based on your class.
            </li>
            <li>
              Move the newly created Interface to the 'RepositoryContracts'
              folder in the 'Demo.DataAccess.Contracts' project and update the
              interfaces namespace accordingly. This not only helps keep your
              architecture clean but will also make it a lot simpler if you
              ever need to switch out your data source in the future.
            </li>
            <li>
              You will now need to update your using statement in your class so
              you can reference the interface in its new location.
            </li>
            <li>
                Now your Repository and its interface have been created you will now need to register them in the IOC container ready for dependency Injection.
                .NET Core 2 has a built in IOC container and the dependencies are registered in the startup.cs class. Follow these steps to register your new Repository for dependency injection.
                <ul>
                    <li>
                        Navigate to the Startup.cs class in your Demo.Api project
                    </li>
                    <li>
                        Under the AddCustomServices function add the following <code>services.AddTransient&lt;<em>YourInterface</em>, <em>YourClass</em>>&gt;();</code>
                    </li>
                    <li>
                        That's it, the repo is now registered for DI. To understand the difference between AddTransient, AddScoped and AddSingleton, check out the .NET core tutorial on dependency injection.
                    </li>
                </ul>
                
            </li>
          </ol>
          <Header as="h4">Part 2 - Add your service</Header>
          <p>
             Now we have a source of data through our solution, we're going to want to do something with that data, that's where the service layer comes in. Any business logic that needs to be performed on the data should be performed here. Follows these steps to create and setup your service.
          </p>
          <ol>
            <li>
               Add a new class to the Services folder in your Demo.Service project
            </li>
            <li>
                Now you have your Service class you're going to need to access the repository you created earlier, to keep the code decoupled and testable you're going to want to do this through dependency injection. 
                We already registered the repository dependency in section 1, now we need to access this in our service. This is done by injecting the dependency into a ready only variable through the class’s constructor.
                If you are unsure on how to inject a registered dependency into your class through your constructor I suggest reading through the .NET core dependency injection tutorial <a href="https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-2.2">here</a>
            </li>
            <li>
                Now you have access to your repository, you can create a method in your service which can retrieve the required data. Here's a basic example of how a get method should look in your service. 
                <code>{""}    
                <br/>
                    public async Task&lt;<em>YourClass</em>&gt; GetData(int id) <br/>
                    {'{'} <br/>

                    <div style={{paddingLeft:'20px'}}>var date = null; <br/>

                    try<br/>
                    {'{'} <br/>
                       <span style={{paddingLeft:'20px'}}>data = await _repository.<em>yourRepoFunction</em>(id);</span><br/>
                        {'}'}<br/>
                    catch (Exception e)<br/>                     
                        <span style={{paddingLeft:'20px'}}></span>//This is where you want to handle and log any exceptions<br/>
                    {'}'} <br/>
                    <br/>                   
                        return data;<br/>
                    </div>
                    {'}'}
                </code>{""}
                 <p><br/>
               <em>Please note:</em> This is a basic example and does apply any business logic to the data.</p>
               <br/>
            </li>
            <li>
                Following the same steps as section 1, extract an interface from the service class you have just created.
            </li>
            <li>
                Move the newly created interface to the 'Contracts' folder in the Service project and update your using statements.
            </li>
            <li>
                Following the same steps as section 1, register the service class for dependency injection in startup.cs.
            </li>
            <li>
                That's it! The service is now ready to be used.
            </li>
          </ol>          
          <Header as="h4">Part 3 - Create a data transfer object</Header>
          <p>
              Now we have a service to grab the data we need, we will need an object to map that data to. The service returns the data in the form of a hydrated domain model, to maintain separation of concerns and not expose our internal logic to the client, we will create a Data Transfer Object(DTO) to map our service data to.
              <ol>
                <li>Create a class in the Response folder of the Demo.API.DataContracts project ensuring the access modifier is set to public</li>  
                <li>Create the properties that you would like mapped across from the domain model, these should have the same name as their domain model counterparts. This helps with mapping in the next section</li>                
              </ol>
              <p>That's it for this section. Nice and easy!</p>
          </p>
          <Header as="h4">Part 4 - Setup a mapping profile</Header>
          <p>
              The quickest way to map your domain model to your DTO is to use AutoMapper. AutoMapper in .NET core has been desinged to be very easy to setup and use. All we need to do is setup a new profile and then register it.              
              <ol>
                <li>The mapping profiles are located in the Demo.IoC.Config project under the Profiles folder. To create a new profile, create a new class in this location </li>      
                <li>Add a reference to AutoMapper by adding <code>using AutoMapper;</code> to the top of the class</li> 
                <li>Add a reference to the Common and Data Contracts namespace. As the DTO and domain model and may have the same name, you may want to explicitly name the references, like so...<br/>
                <code>
                  using vm = DemoApi.API.DataContracts; <br/>
                  using dm = DemoApi.Common;
                </code>                  
                  </li>                   
                <li>Ensure the access modifier is set to public and that the class inherits from <code>Profile</code></li>
                <li>In your constructor you want to call the Automappers 'CreateMap' function <br/>
                  <code>CreateMap&lt;dm.Models.<em>yourDomainModel</em>>, vm.Response.<em>yourDTO</em>>&gt;();</code>
                </li>
                <li>
                    So that's your profile created, you just need to let AutoMapper know it exists. This is done the <code>ConfigureMaps</code> function located at the very bottom of the startup.cs.
                    in the Mapper.Initialize initialiser just add the profile you have created, like so... <code>cfg.AddProfile&lt;CustomerMappingProfile&gt;();</code>
                </li>
                <li>Note: If your </li>
              </ol>
              <p>BOOM! That's your AutoMapper profile sorted</p>
          </p>
          <Header as="h4">Part 5 - Create your controllers</Header>
          <p>
            So that's pretty much all the ground work done, now we just need to create controller endpoint for the clients to call. 
            <ol>
              <li>In the controller's folder on the Demo.API project you should see a number of folders each with a different version. if this controller is for a new version of the API, then create a new folder and name it according to the version</li>
              <li>Right click on folder you wish to create a new controller in and then choose 'Controller' under the add section, the choose to create and empty API controller. This will scaffold you a basic controller class</li>              
              <li>Add the correct version attribute to the class list eg.. <code>[ApiVersion("3.0")]</code></li>
              <li>You will also need to ensure you add the version to the route. So if this was a version 3 controller you will need to change <code> [Route("api/[controller]")]</code> to <code> [Route("api/v3/[controller]")]</code></li>
              <li>Now you will need to inject in your AutoMapper and you Service through the constructor
                  <code>
                    <br/><br/>
                  private readonly IMapper _mapper; <br/>                  
                  private readonly ICustomerService _service;<br/><br/>               
                  public CustomerController(IMapper mapper, ICustomerService service)  <br/>                  
                {'{'}  <br/>                  
                <span style={{paddingLeft:"20px"}}>_mapper = mapper;  </span><br/>
                <span style={{paddingLeft:"20px"}}>_service = service; </span>  <br/>                  
                {'}'}  <br/>                  
                  </code>
              </li>
                <li>Now you're ready to create your GET method. The methods in your controller should not do anything more than map your hydrated domain model to your DTOs. So your GET function should look no more complex than this
                  <br/>
                  <code><br/>
                  public async Task&lt;ActionResult&lt;IEnumerable&lt;vm.Response.<em>yourDto</em>&gt;&gt;&gt; Get()<br/>
                  {'{'}<br/>
                  <span style={{paddingLeft:"20px"}}>  return _mapper.MapIEnumerable&lt;vm.Response.<em>yourDto</em>&gt;&gt;(await _service.<em>yourGetFunctionInService</em>>()).ToList(); </span><br/>
                  {'}'}<br/>
                  </code>
                  <br/>                  
                </li>
                <li>
                  Now we just need to add some decorations to your method. most importantly we need to let the method know what type of request it is meant to receive. To do this, simply add the <code>[HttpGet]</code> attribute to the top of the method.
                  It is also a good idea to specify the different types of respose the method is likely to give, you can do this with the  Produces Response Type attribute. So add the following attributes to your method <br/><code>[ProducesResponseType(200)]<br/>
        [ProducesResponseType(204)] </code><br/>
          These are particularly useful as we are using Swashbuckle to generate our swagger endpoint. Swashbuckle reads these attributes and passes the knowledge onto the swagger client.
                </li>
            </ol>
          </p>
        </p>
        <p>
          That's it!! We created a whole new endpoint and data pipeline. To test, rebuild your solution, run and check the endpoint in swagger.
        </p>
        <p>
          These may seem like a lot of work at first, but it is actually really fast getting a new pipeline setup once you are used to the process. Following this process for new pipelines helps to keep our architecture clean, testable, scaleable and maintainable.
        </p>
       </div>
    );
  }
}

export default AddEndPoint;
