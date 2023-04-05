import React, {useState} from "react";
import axios from "axios";
import PropTypes from 'prop-types';

async function loginUser(credentials) {
    return fetch('https://localhost:7180/authentication', {
      method: 'POST',
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(credentials)
    })
      .then(data => data.json());
}



export default function Login({setToken}){

    const [login, setLogin] = useState();
    const [password, setPassword] = useState();

    const handleSubmit = async e => {
        e.preventDefault();
        const token = await loginUser({
          login,
          password
        });
        
        let data = status({
            login,
            password
          });
        console.log((await data).valueOf);
        localStorage.setItem('jwt',data);
        setToken(token);
    }
    
    function status(credentials)
    {
        const url = 'https://localhost:7180/authentication';
        let data = axios.post(url, credentials).then(response => response.status);
       // console.log(JSON.parse(data));
        return  data;
    }
    

    function registrate()
    {
        const url = `https://localhost:7180/api/User`;
        return axios.post(url,{
            login,
            password
        }).then(response => console.log(response.status));
    }
    

    return (
            <div>
                 <header className="App-header">
                    <div>Vulngramm</div>
                </header>
                <br></br>
                <div className="logwin">
                    <div>
                        <input id="login" type="text" className="TextPlace"  onChange={e => setLogin(e.target.value)}></input>
                    </div>
                    <div>
                        <input id="password" type="password" className="TextPlace" onChange={e => setPassword(e.target.value)}></input>
                    </div>
                    <div>
                        <button type="submit" id = "submit" onClick ={handleSubmit} hidden>Login</button>
                        <label for = "submit" className="button">Login</label>
                        <button type="submit" id = "reg" hidden onClick={registrate} >Registrate</button>
                        <label for = "reg" className="button" >Registrate</label>
                    </div>
                </div>
            </div>
    );
}

Login.propTypes = {
    setToken: PropTypes.func.isRequired
 };