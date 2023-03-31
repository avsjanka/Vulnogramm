import React from 'react'
import axios from 'axios';

export class Home extends React.Component {

  static displayName = Home.name;
    constructor(props) {    
      super(props);    
      this.state = {    
              file: '',    
      };    
  }

  async submit(e) {    
      e.preventDefault();    
      //const url = `https://localhost:7180/api/FileUploads?method=1`;  
      const url = `https://localhost:7180/api/FileUploads`;  
      const file = new FormData();    
      file.append('file', e.target.files[0]);    
      let method = 2;
      file.append('method', 1);
     const config = 
     {    
        headers: 
        {    
          'content-type': 'multipart/form-data',  
          'accept': 'text/plain',
        },    
      };   
      return axios.post(url, {
        file : e.target.files[0],
       data: 1,
      },config).then(response => console.log(response.status));    
  }

  setFile(e) {    
      this.setState({ file: e.target.files[0] });  
  } 

  render() {
    return (
      <div >
          <form onSubmit={e => this.submit(e)}>  
            <input type="file" accept="image/png,image/bmp,image/svg" id="upload" hidden  onChange={e => this.submit(e)}></input>
            <label for="upload" className="button">Choose your photo</label>
          </form> 
      </div>
    );
  }
}


export default Home;