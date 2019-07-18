import * as React from 'react';
import {Header, Image} from "semantic-ui-react";

class SolutionTour extends React.Component {
    state = {}
    render() { 
        return ( 
            <div>
                <Header as='h3'>Solution Tour and architecture</Header> 
                <p>The Demo API solution is broken in to 15 separate  projects, this helps keep the code decoupled and highly reusable. I find it also help with navigating the architecture and readability</p>                
                <p>Here is a list of the projects in the solution... </p>
                <Image            
                    style={{marginBottom:"10px", height:"300px" }}
                    src={require("../content/images/solution.jpg")}
                /> 
                <Header as="h4">Project Breakdown</Header>
                 <ol>
                     <li>
                        <strong>CryptoLib</strong> <br/>                     
                        <p>CryptoLib is an AES 256 Encryption library I created a while back, designed to make adding Rijndael encryption to .NET applications as easy as possible. This library is currently not actively being use by the demo API, but has been included for future use.</p>
                        <p>For more details and tutorials on CryptoLib, take a look at github page <a href="https://github.com/FlumpStudios/CryptoLib" target="_blank">here</a></p>
                    </li>
                    <li>
                        <strong>Demo.API</strong><br/>
                        <p>This is where the magic happens! The Demo.API contains the controllers and therefore the endpoints for the API.</p>                                          
                    </li>
                    <li>
                        <strong>Demo.API.DataContracts</strong><br/>
                        <p>These may also be known as your view models. These are the models that the domain models will be mapped to in the API controllers and therefore are the models that are exposed to the UI. This project consists of 2 folders, your requests and responses</p>                                          
                        <p>The request models are for mapping requests from the UI layer (such as new data to POST or PUT). The responses models are for mapping the responses from the service (such as a response to a GET request).</p>
                    </li>                      
                    <li>
                        <strong>Demo.Caching.Contracts</strong><br/>
                        <p>This simply holds the interface for your caching implementation. Having the interface in a separate project makes it easy to switch out your caching technique if you should need to. Any reference to caching in the project should be using the interface contained in this project, this means if you need to switch out memory cache for  distributed cache, you can do so with minimal disruptions to the code or architecture.</p>
                    </li>
                    <li>
                        <strong>Demo.Caching.MemCache</strong><br/>
                        <p>This is a little memory caching library I wrote to help decouple the memory caching from code. This means you can have a centralised location for configuring your memory cache, this also makes it easier to switch out your caching implementation if you need to.</p>                        
                    </li>
                    <li>
                        <strong>Demo.Common</strong><br/>
                        <p>
                            This project houses any code which is expected to be shared between the other projects such as extension and helper methods. This is also where you can find your domain models.
                        </p>
                    </li>
                    <li>
                        <strong>  Demo.DataAccess.Contracts</strong><br/>
                        <p>
                            This project contains the interfaces for the repositories. These are held in a separate project to the concrete classes so that it is relatively easy to switch out your database solution if you ever needed to.
                        </p>
                    </li>
                    <li>
                        <strong>Demo.DataAccess.EntityFramework</strong><br/>
                        <p>
                            This is the EntityFramework implementation of the DAL and contains the concrete classes for the solutions repositories. This project should contain nothing but the repositories for accessing the data from DB. 
                        </p>
                        <p>
                             You may also notice there is a generic repository included in this project. This is for any calls that you think may not fit within the current repos but are maybe too small to create a whole new repo for.
                             Filtering and ordering in the generic repo is handled by delegates.  
                        </p>
                    </li>
                    <li>
                        <strong>Demo.IoC.Config</strong><br/>
                        <p>
                            Use this project to setup anything that will be used in setting up the IOC container such as OperationFilters, mapping profiles or customer swagger classes.
                        </p>
                    </li>
                    <li>
                        <strong>Demo.Service</strong><br/>
                        <p>
                        This is the big one! This is where all the services live for you solutions. The service methods will take data from the repositories, perform the required business logic and serve to the controller, ready to map to the view models. Any required business logic should be performed in this project.
                        </p>                    
                    </li>
                    <li>
                        <strong>Demo.Tests</strong><br/>
                        <p>
                           This project contains all your tests and mocks for the entire solution. The tests for this solution are written using MStest and MOQ is used for mocking.
                        </p>                    
                    </li>
                    <li>
                        <strong>Identity.Admin</strong><br/>
                        <p>
                           This is a stand-alone ASP.NET application which is used as the admin area for the Identity server. This is where you can setup your users and permissions for your solution. This project uses Skoruba for the UI, for more information visit their GIT hub <a href="https://github.com/skoruba/IdentityServer4.Admin" target="_blank">here</a>.
                        </p>                    
                    </li>
                    <li>
                        <strong>Identity.STS.Identity</strong><br/>
                        <p>
                           This is the token service for the solution which issues JWTs and handles validations and SSO. This project uses Identity Server 4 to handle the authentication and authorisation. For more details about Identity Server 4 visit their site here <a href="http://docs.identityserver.io/en/latest/" target="_blank">here</a>.
                        </p>                    
                    </li>
                    <li>
                        <strong>ReactClient</strong><br/>
                        <p>
                           This is what you are looking at now. This is a react client with Redux, Axios, React Router 4, semantic-ui and permission mapping to give a great jumping off point for creating a client to your API. For more info on react check out the official site <a href="https://reactjs.org/" target="_blank">here</a>.
                        </p>                    
                    </li>



                  
                 </ol>
            </div>

         );
    }
}
 
export default SolutionTour;