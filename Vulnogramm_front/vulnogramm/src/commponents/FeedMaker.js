import Table from "./ImageTable";
import Image from "./ImageDialog";
import React from 'react';

export default class FeedMaker extends React.Component {
    constructor(props) {
        super(props);
        this.state={
            fullTable: [],
        }
        this.addImage =this.addImage.bind(this);
        this.logFeed = this.logFeed.bind(this);
    }


    async logFeed() {
        function makeFeed() {
            return fetch('https://localhost:7180/feed', {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
            })
                .then(data => data.json());
        }
        const AllPosts = await makeFeed();
        console.log(AllPosts);
        let newPosts = [];
        for (let i = AllPosts.length; i--;)
        {
            newPosts = newPosts.concat(<Image photoData={AllPosts[i]}/>);
        }
        this.setState( {fullTable: newPosts}, function (){console.log("add success")});
    }
    
    async addImage(img) {
        console.log(img);
        this.setState( {fullTable: this.state.fullTable.concat(<Image photoData={img}/>)}, function (){console.log("add success")});
    };
    render() {
        return (
            <div className="FeedMaker">
                <Table Table={this.state.fullTable} />
                <button id="seeFeed" onClick={this.logFeed}>feed</button>
            </div>
        );
    }
}