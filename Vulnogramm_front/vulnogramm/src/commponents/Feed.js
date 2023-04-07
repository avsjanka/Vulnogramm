import React, { useState} from 'react';
import Post from './Post';
import Login from './Login';

export default function Feed() {
  const [showModal, setShowModal] = useState(false);
  const [token, setToken] = useState();
  
  const toggleShowModal = () => {
    setShowModal(!showModal);
  };

  function logout()
  {
    document.cookie = null;
    localStorage.setItem('jwt',null);
    setToken(null);
  }

  if(token==null)
  {
    return <Login setToken={setToken} />
  }

  return(
    <div className='feed'>
        <Post show={showModal} close_button_click={toggleShowModal} />
        <button id="new_post" onClick={toggleShowModal} hidden></button>
        <label for="new_post" className="button"> New post</label>
        <button onClick={logout}>Logout</button>
    </div>
  );
}