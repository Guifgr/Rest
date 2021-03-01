import React from 'react';
import {BrowserRouter, Route, Switch} from 'react-router-dom';

import Login from './pages/login';
import Books from './pages/books';
import NewBook from './pages/NewBook';


export default function Routes() {
    return (
        <BrowserRouter>
            <Switch>
                <Route path="/" exact component={Login}/>
                <Route path="/books" exact component={Books}/>
                <Route path="/books/new/:bookId" component={NewBook}/>
            </Switch>
        </BrowserRouter>
    );
}