import React, { useState } from 'react';
import './App.css';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Home from './commponents/Upload';
import Login from './commponents/Login';
import Feed from './commponents/Feed';

function App() {
  const [token, setToken] = useState();

  if(token==null) {
    return <Login setToken={setToken} />
  }

  return (
    <div className="App">
      <header className="App-header">
        <div>Vulngramm</div>
      </header>
      <br></br>
      <BrowserRouter>
        <Routes>
          <Route path="/feed" element={<Feed />} />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
