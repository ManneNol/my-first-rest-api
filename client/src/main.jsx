import { StrictMode, useEffect, useState } from "react";
import { createRoot } from "react-dom/client";
import { BrowserRouter, Routes, Route } from "react-router";

createRoot(document.getElementById('root')).render(
    <StrictMode>
        <BrowserRouter>
            <Routes>
                <Route index element={<HomePage/>}/>
            </Routes>
        </BrowserRouter>
    </StrictMode>
);

function HomePage()
{
    return <main>
        <h1>Home Page</h1>
        <UserList />
    </main>
}

function UserList()
{
    const [users, setUsers] = useState([]);
    const [shouldRefresh, setShouldRefresh] = useState(false);

    /*
    useEffect(()=>{
        async function fetchUsers()
        {
            let response = await fetch("/api/users");
            response = await response.json();
            setUsers(response);
        };
        fetchUsers();
    }, []);
    */

    useEffect(()=>{
        fetch("/api/users")
        .then(response => response.json())
        .then(data=>{setUsers(data)})
    });
    return <ul>
        <button onClick={()=>setShouldRefresh(current => !current)}>Refresh List</button>
        {users.map((user)=><li key={user.id}>{user.name}</li>)}
        </ul>
}
