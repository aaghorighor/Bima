import React from 'react';
import { Switch, Redirect } from 'react-router-dom';
import { RouteLayout } from './components';
import { Main as MainLayout, Minimal as MinimalLayout } from './layouts';

import {
  Dashboard as DashboardView,   
  Settings as SettingsView,
  SignUp as SignUpView,
  SignIn as SignInView,
  Users as UserView,
  NotFound as NotFoundView
} from './views';

const Routes = () => {
  return (
    <Switch>
      <Redirect
        exact
        from="/"
        to="/sign-in"
      />
      <RouteLayout
        component={DashboardView}
        exact
        layout={MainLayout}
        path="/dashboard"
      />             
      <RouteLayout
        component={SettingsView}
        exact
        layout={MainLayout}
        path="/settings"
      />
      <RouteLayout
        component={UserView}
        exact
        layout={MainLayout}
        path="/users"
      />      
      <RouteLayout
        component={SignUpView}
        exact
        layout={MinimalLayout}
        path="/sign-up"
      />
      <RouteLayout
        component={SignInView}
        exact
        layout={MinimalLayout}
        path="/sign-in"
      />
      <RouteLayout
        component={NotFoundView}
        exact
        layout={MinimalLayout}
        path="/not-found"

      />
      <Redirect to="/not-found" />
    </Switch>
  );
};

export default Routes;
