"use client";
import React, { useEffect, useState } from 'react';
import { FaPlusCircle } from 'react-icons/fa'
import ProductCard from './ProductCard';

export default function Home() {
    const [publications, setPublications] = useState([]);
    useEffect(() => {
        async function fetchPublications() {
            try {
                const response = await fetch('https://projet07-dicjprog4.cegepjonquiere.ca/api/Cosplays', {
                    method: 'GET',
                });
                const data = await response.json();
                setPublications(data);
            } catch (error) {
                console.error('Erreur lors de la récupération des publications:', error);
            }
        }
        fetchPublications();
    }, []);

    return (
        <>
        <div className='d-flex justify-content-end m-3' >
            <button className="btn btn-primary me-2 ">
                <a className='text-decoration-none text-white' href={`../AjoutProduit`}>
                    <FaPlusCircle /> Ajouter
                </a>
            </button>
        </div>
        <div className="row" id="Publication">
            {publications.map(publication =>
                <ProductCard key={publication.id} {...publication} />
            )}
        </div>
        </>
    );
}