"use client";
import React, { useEffect, useState } from 'react';
import ProduitDetail from './ProduitDetail';
import UserContext from './UserContext';

export default function Home({ params }) {
    return (
        <>
            <UserContext.Provider value={params.id}>
                <ProduitDetail></ProduitDetail>
            </UserContext.Provider>
        </>
    )
}


