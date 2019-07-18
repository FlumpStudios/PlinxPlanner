import * as React from 'react';
import { RouteComponentProps } from 'react-router-dom';
import { Header } from 'semantic-ui-react';
import { NavLink, Link } from "react-router-dom";
export default class Dashboard extends React.Component<RouteComponentProps<{}>, {}> {

    state = {
        result: null
    }    

    public render() {
        return (
            <div>
                <Header as="h1">Welcome to the Listers Demo API</Header>
                <Header as="h3">What is this?!</Header>
                <p>
                    This solution serves as a boilerplate VS solution which can be used a jumping off point for creating a new .NET core 2.2 API project, with a swagger and react client
                </p>
                <p>
                    The solutions includes Swagger intergration, Code first EF with seeding, controller to service mapping, STS/SSO with ID server 4, ID Admin area with Skoruba, unit testing with MSTest, memcaching, AES 256 Encryption and logging to db with NLOG. The solution also contains a react client with Typescript, Redux, Semantic-UI, Routing, Open ID connect, Axios and role to permission mapping.
                </p>                          
                <Header as="h3">So what now?</Header>                
                <p>
                    Not sure what to do now? Got some time to spare? Why not check out these links to find our more about the Listers Demo API.
                </p>
                <p>
                    <Link to='Setup'>Basic Setup</Link> 
                </p>
                <p>
                    <Link to='SolutionTour'>Solution Tour and architecture</Link> 
                </p>
                <p>
                    <Link to='DataFlow'>Data flow of a standard request</Link>
                </p>
                <p>
                    <Link to='AddEndPoint'>Quick guide to adding a new endpoint</Link>
                </p>
                <p>
                    <Link to='SuggestReading'>Suggested reading and tutorials</Link>
                </p>
                <p>
                    <Link to='ApiTable'>Call the API</Link>
                </p>
                <p>
                    <Link to='user'>View the OIDC user information</Link>
                </p>



            </div>
        )
    }
}
