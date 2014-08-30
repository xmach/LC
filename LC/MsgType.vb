Public Enum MsgType
    'resetClient = 1
    'beginGame = 2 'initialize vocabulary
    'setID = 3
    'finishedInstructions = 4
    'requestIP = 5
    'endGame = 6
    'showResult = 7
    Client_finishedInstructions = 4
    Client_sendLearnInvent = 21
    Client_sendPhase1Decision = 23
    Client_sendPhase2Decision = 25
    Client_newRound = 27

    Server_endEarly = 12
    Server_readInstruction = 19 'show instructions 
    Server_languageDecision = 20
    Server_feedbackScoreMatrix = 22
    Server_feedbackPhase1Decision = 24
    Server_feedbackResult = 26

End Enum
