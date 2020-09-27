import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { createStore, applyMiddleware, compose } from 'redux';
import reduxThunk from 'redux-thunk';

import App from './App';
import reducers from './reducers';

//const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');

const rootElement = document.getElementById('root');
const composeEnhancer = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose; 
const store = createStore(reducers, composeEnhancer(applyMiddleware(reduxThunk)));

ReactDOM.render(
    <Provider store={store}>
      <App/>
    </Provider>,
  rootElement);

