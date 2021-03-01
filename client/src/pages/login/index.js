import React ,{useState} from "react"
import {useHistory} from 'react-router-dom'
import api from "../../services/api"

import logoImage from "../../assets/logo.svg"
import padLock from "../../assets/padlock.png"
import  "./style.css"

export default function Login(){

    const [userName, setUserName] = useState("");
    const [password, setpassword] = useState("");
    const history =useHistory();

    async function login(e){
        e.preventDefault();

        const data ={
            userName,
            password
        };

        try {
            const response = await api.post('/api/Auth/v1/signin', data);
            localStorage.setItem('userName', userName);
            localStorage.setItem('acessToken', response.data.acessToken);
            localStorage.setItem('refreshToken', response.data.refreshToken);
            history.push('/books')
        } catch (error) {
            alert("Login Failed, Try again!");            
        }

    }

    return(
        <div className="login-container">
            <section  className="form">
                <img src={logoImage} alt="ErudioLogo"/>
                <form onSubmit={login}>
                   <h1 >Access your Account</h1> 

                    <input 
                        type="text"
                        name="Username"
                        placeholder="Username"
                        value={userName}
                        onChange={e => setUserName(e.target.value)}
                    />
                    
                    <input
                        type="password"
                        name="Password"
                        placeholder="Password"
                        value={password}
                        onChange={e => setpassword(e.target.value)}
                    />
                   
                    <button className="button" type="submit">Login</button>                    
                </form>
            </section>
            
            <img src={padLock} alt="Login"/>
        </div>
    );
}
