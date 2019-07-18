import * as React from 'react';
import { connect } from 'react-redux';
import { Route, Switch } from 'react-router-dom';
import { RouteComponentProps } from 'react-router';
import CallbackPage from './components/CallbackPage';
import { ApplicationState } from './store';
import userManager from './userManager';
import { User } from 'oidc-client';
import Layout from './containers/Layout';
import axios from 'axios';
import Dashboard from './containers/Dashboard';
import UserInfo from './components/UserInfo';
import ability from './permissions/ability';
import permissionsList from "./Permissions/permissionsManager";
import Setup from './components/Setup'
import SolutionTour from './components/SolutionTour'
import DataPipeline from './components/DataPipeline'
import SuggestReading from './components/SuggestedReading'
import ApiTable from './components/ApiTable'
import AddEndPoint from './components/AddEndpoint'

type RoutesModuleProps =
    { user: User, isLoadingUser: boolean }
    & RouteComponentProps<{}>
    & { dispatch: any }

class RoutesModule extends React.Component<RoutesModuleProps, {}>{

    render() {
        // wait for user to be loaded, and location is known
        if (this.props.isLoadingUser || !this.props.location) {
            return null;
        }


        // if location is callback page, return only CallbackPage route to allow signin process
        if (this.props.location.pathname == '/callback') {
            return <Route path='/callback' component={CallbackPage} />
        }

        // check if user is signed in
        userManager.getUser().then(user => {
            if (user && !user.expired) {
                // Set the authorization header for axios
                axios.defaults.headers.common['Authorization'] = 'Bearer ' + user.access_token;

                //Update user permission
                ability.update(permissionsList.getPermisisonsList(user.profile.role));
            }
        });

        let isConnected: boolean = !!this.props.user;

        return (
            <Switch>
                <Layout isConnected={isConnected}>
                    <Route exact path='/' component={Dashboard} />                    
                    <Route path='/user' component={UserInfo} />
                    <Route path='/Setup' component={Setup} /> 
                    <Route path='/SolutionTour' component={SolutionTour} /> 
                    <Route path='/DataFlow' component={DataPipeline} /> 
                    <Route path='/SuggestReading' component={SuggestReading} /> 
                    <Route path='/ApiTable' component={ApiTable} />
                    <Route path='/AddEndPoint' component={AddEndPoint} />
                </Layout>
            </Switch>
        )
    }
}

function mapStateToProps(state: ApplicationState) {
    return {
        user: state.oidc.user,
        isLoadingUser: state.oidc.isLoadingUser,
    };
}

function mapDispatchToProps(dispatch: any) {
    return {
        dispatch
    };
}

export default connect(mapStateToProps, mapDispatchToProps)(RoutesModule);