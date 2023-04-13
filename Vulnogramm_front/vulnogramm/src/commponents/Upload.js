import React, { useState } from 'react';
import FileSaver from 'file-saver';
import  handleChangeFile from 'file-saver';
import  handleFile from 'file-saver';

export default function Home ({setPhoto}){



function handleFile(e){      
    let content = e.target.result;
    setPhoto(content);
  }
    
  function handleChangeFile(file){
      let fileData = new FileReader();
      fileData.onloadend = handleFile;
      fileData.readAsDataURL(file); 
  }



    return (
      <div >
          <form onSubmit={e => this.submit(e)}>  
            <input type="file" accept="image/png,image/bmp,image/svg" id="upload" hidden  onChange={e => handleChangeFile(e.target.files[0])}></input>
            <label id="upload_label" for="upload" className="button">Choose your photo</label>
          </form> 
      </div>
    );

}



