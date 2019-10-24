import React, {Component} from 'react'
import ReactDOM from 'react-dom'
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import WrappedNormalLoginForm from './components/Login';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import 'antd/dist/antd.css';


export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <WrappedNormalLoginForm />
      // <Layout>
      //   <Route exact path='/' component={Home} />
      //   <Route path='/login' component={Login} />
      //   <Route path='/counter' component={Counter} />
      //   <Route path='/fetch-data' component={FetchData} />
      // </Layout>
    );
  }
}
