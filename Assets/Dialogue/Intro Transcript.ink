VAR choiceNum = -1
VAR commandName = "None"
VAR commandCount = 0

#mode: reader
Hi, How are you doing#speaker:Athena
Hello, pleased to make your acquaintance#speaker: Tobias
Do you know who I am?#speaker:Athena
Was the food good?#speaker: Tobias
Excuse me? #speaker:Athena
Your breakfast.#speaker: Tobias
I had a feeling you would like it.
... <i> The <link=case_log?><b>Case file</b></link> said he would try to put me off balance, but this is...</i>#speaker:Athena
One of the few allowances they give us on this ship is cooking for other members. There is something holy in the skillet. It is as if a piece of me is now inside you. Like all art forms, it has a beauty to it, but there is something glorious in the fact that a piece of me now makes up and will make up your skin, blood, and organs.# speaker: Tobias
<i> Interesting imagery... </i> # speaker: Athena
Of course I know who you are, you're infamous. Let me tell you Athena,, not just anyone gets onto the Sisypus. speaker: Tobias

* [Figure out how much he knows. Any power imbalance between therapist and client can be exploited]
    How did you know I like eggs and tuna?
    I know that I was right. My ability to read people never fails me. <link=barnumstatement><b>You strike me as someone who prefers change and does not like to feel limited in what you can do. </b></link>You're an independent thinker who takes pride in doing things differently. You can be loud and outgoing, but also quiet and reserved. # speaker: Tobias
* [Try to call his bluff. It isn't going to be that easy to throw you off].
    Yeah nice try. I didn't eat breakfast. # speaker: Athena
    You can't blame me for trying, alright. Playing with the staff is one of the only things in the world left to me.# speaker: Tobias
- Well, who exactly does get onto the Sisyphus then? # speaker: Athena
    Why are we doing this dance? Listen, we both understand how this game is played, I'm not some spoiled billionaire brat, I made my own money you know. I want me better just as much as you do.
    *   [Press him further]
    Oil rigs are some of the most secluded, depressing, and repressed pressure-cookers of scum that are only barely able to function for 6 months to a year by greasing the pores of poor sods with money, benefits, and psychiatrists. Just the situation itself breaks the mind. Now imagine doing that for years, with some of the 'allegedly'... I'm innocent'... most dangerous minds in our society that <link=activelydamage><b>are actively trying to damage your mental health</b></link>, except instead of having a therapist, you are it. Even if you had the talent, which almost none do, you wouldn't have the stomach, even if you had both, you'd have to be a woman too. So I guess what I'm saying is that it takes a type of person. # speaker: Toby
    
    What do you mean by that?# speaker: Athena
    
    Suicidal and apparently stupid enough to <link=fakemeal><b>let a convict convince her into thinking I actually cooked your fucking meal</b></link> # speaker: Toby
    *   [Let him change the subject]<i>... I think I'm just going to let him change the subject </i>
- I'm glad to hear that. Let's start with your name.
I'm Gorgon K-08323, Toby
Describe yourself.
I'm something of a hero, I guess. I don't think much of what I am, but that's the moniker people give me.
How does a hero end up in a prison ship 20,000 leagues under the sea?
I don't know, repressed anger? Isn't your job to find out that kind of information? I run a media conglomerate called C72. It's essentially a network of publishers for different types of media in the arts. It's become rapidly successful as the artist-owned structure of the subsidiaries allows for rapid innovation in the field, and all that revenue is funneled into increasing production of the arts in New Turkey.
Is there a specific kind of art that you greenlight?
Listen, I'm no Weinstein. <link=productionhouses> <b>I try not to put my personal touch into what gets in and out of the production houses</b></link> # mode:puzzle 
~choiceNum = 0
~commandName = "Confront"


#case_log #productionhouses 
~commandCount = commandCount + 1

~choiceNum = 1
~commandName = "Manipulate"

#case_log #fakemeal 
~commandCount = commandCount + 1

* [Confront] I see a pattern among the movies you choose. Big guys versus the small guy. Standing up to bullies. You're a power fantasy type guy. And you're a powerful person. # speaker: Athena
    ... You can draw conclusions in anything. Did you know the ancient Aztecs feasted on the hearts of those who played their sacred games. And not the losers too, they feasted on the winners # speaker: Tobias
    <i> Why is he saying this to me. Is it some kind of power play? </i> # speaker: Athena
    
* [Manipulate] So what I'm hearing so far is that generally you aren't a person who feels comfortable being in control. You let others express themselves and let the best idea win out. # speaker: Athena
    Analysis so early in the conversation? I wonder what they put in my file... Yeah, I try to be a little hands-off and not piss other people off. # speaker: Tobias
    And does that make you feel? <i> It never gets old </i>
    #mode: reader
- Everything i do, or did, was to make the world a better place and Strike at the heart of the world's issues. All we are, are fleshy apes with a mouth. People victimize one another because of the narratives they have in their heads. Change the narratives people have, we change reality itself, and we may just save humanity along with it. I believe in doing anything for that.
* <i> Who gets to decide which narratives are the important ones? You[?] And what narrative allows you to think it's okay to kill people. A lot of people. That's what I want to know </i> # speaker: Athena
- So in a sense, I'm not surprised that people call me a hero. Toby the Hero...#speaker: Toby
<i> There's something more there </i>
Let's talk a little more about that
I just remembered something #speaker: Toby
What?
Why it's so important for me to protect the little guy. You see, I was the little guy. Do you want to know why bullying is so horrible? Bullying is horrible because not only do bullies destroy your ability to make friends, they turn what friends you do have left into bullies. 
    -> END
