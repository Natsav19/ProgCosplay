"use client";
import React, { useState } from 'react';

async function confirmerInscription(formData) {
    const https = require('https');
    const agent = new https.Agent({
        rejectUnauthorized: false
    });
    let user = formData.get("username");
    let email = formData.get("email");
    let password = formData.get("password");
    var nouvelleInscription = {
        "email": email,
        "password": password,
        "username": user,
        };   
    console.log(email) ;
    console.log(user);
    console.log(password);
    const reponse = await fetch("https://projet07-dicjprog4.cegepjonquiere.ca/api/Authentification/register", {
        method: 'POST',
        agent,
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(nouvelleInscription),
        })
}
 
export default function Home() {
    return (
        <div className="container mt-5 d-flex flex-column justify-content-center align-items-center">
            <div className="card w-75 mb-4 p-5">
            <h1 className="text-center mb-4">Inscription</h1>
            <form className='d-flex flex-column justify-content-center align-items-center' action={confirmerInscription}>
                <div className="mb-3 w-75">
                    <label htmlFor="username" className="form-label">Nom d'utilisateur</label>
                    <input type="text" className="form-control" id="username" name="username" required/>
                </div>
                <div className="mb-3 w-75">
                    <label htmlFor="email" className="form-label">Adresse email</label>
                    <input 
                    type="email" 
                    className="form-control" 
                    id="email" 
                    name="email"
                    required 
                />
                </div>
                <div className="mb-3 w-75">
                    <label htmlFor="password" className="form-label">Mot de passe</label>
                    <input type="password" className="form-control" id="password" name="password" required />
                </div>
                <button type="submit" className="btn btn-primary">S'inscrire</button>
            </form>
            </div>
        </div>


    );
}