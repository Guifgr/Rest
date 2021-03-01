import React, {useState, useEffect} from 'react';
import { Link, useHistory } from 'react-router-dom';
import api from "../../services/api"
import './style.css'
import logoImage from "../../assets/logo.svg"
import { FiPower, FiEdit, FiTrash2 } from 'react-icons/fi'

export default function Books(){
    const history = useHistory();  
    const [books, setBooks] = useState();
    const userName =localStorage.getItem("userName");    
    const accessToken = localStorage.getItem('acessToken');  
    const authorization = {
        headers: {
            Authorization: `Bearer ${accessToken}`
        }
    }   

    useEffect(() => {
        api.get('/api/Book/v1', authorization).then(response =>{
                setBooks(response.data)
        })});

    async function deleteBook(id){
        try {
            await api.delete(`/api/Book/v1/${id}`, authorization);
            setBooks(books.filter(book => book.id !== id)) 
        } catch (err) {
            alert("Delete failed")
        }
    }
    async function editBook(id){
        try {
            history.push(`/books/new/${id}`)
        } catch (err) {
            alert("Edit failed")
        }
    }
    
    async function logout(){
        try {
            await api.get(`/api/Auth/v1/revoke`, authorization);
            localStorage.clear();
            history.push('/')
        } catch (err) {
            alert("Logout failed")
        }
    }

    let itemsToRender;
    if(books){
        itemsToRender = books.map(book =>{
            return(
                <li>
                   <strong>Title</strong>
                   <p>{book.title}</p>
                   <strong>Author</strong>
                   <p>{book.author}</p>
                   <strong>Price</strong>
                   <p>{book.price.toFixed(2)}</p>
                   <strong>Release date</strong>
                   <p>{book.launchDate}</p>

                   <button onClick={()=>editBook(book.id)} type="button">
                       <FiEdit size={20} color="251fc5"/>
                   </button>
                   <button onClick = {() => deleteBook(book.id)} type="button">
                       <FiTrash2 size={20} color="251fc5"/>
                   </button>
                   
               </li>
            )
        })
    } else { itemsToRender = "Wont worked :("; }



    return(
        <div className="book-container">
            <header>
                <img src={logoImage} alt="Erudio"/>
                <span>welcome, <strong>{userName.toUpperCase()}</strong>!</span>
                <Link className="button" onClick={()=>editBook(0)}>Add new book</Link>
                <button onClick={logout} type="button">
                    <FiPower size={18} color="251fc5" />
                </button>
            </header>

            <h1>Registered Books</h1>
            <ul>
               {itemsToRender}
            </ul>
        </div>
    );
}
