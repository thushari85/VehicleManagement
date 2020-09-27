import React from 'react';
// import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import CarAdd from './components/forms/Car/CarAdd';
import CarList from './components/lists/CarList';

import './custom.css'
//import { BrowserRouter } from 'react-router-dom';
import { Router, Route } from 'react-router-dom';

import history from './history';
import errorBoundry from './ErrorBoundry';

class App extends React.Component {
  static displayName = App.name;

  render () {
    return (
      <Router history={history}>
        <Layout>
          <Route exact path='/' component={Home} />
          <Route exact path="/car" component={CarList} />
          <Route exact path='/car/new' component={CarAdd} />
        </Layout>
      </Router>
    );
  }
}

export default errorBoundry(App);
