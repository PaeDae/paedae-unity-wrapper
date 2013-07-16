//
//  PaeDaeUnityImpl.mm
//
//
//  Created by Greg Morrison on 11/13/12.
//  Copyright (c) 2012 PaeDae Inc. All rights reserved.
//

#import "PaeDaeUnityImpl.h"

@implementation PaeDaeUnityImpl

- (id)init
{
    self = [super init];
    if (self) {

    }

    return self;
}

- (void)dealloc
{
    [super dealloc];
}

@end

extern "C"
{
    void _InitWithKey()
    {
	// add YOUR own key here
        [[PaeDaeSDK sharedManager] initWithKey:@"b00015e0-5cf7-012f-c818-12313f04f84c"];
    }

    void _ShowPrizeWithOptionsAndDelegate()
    {
        //[[PaeDaeSDK sharedManager] showPrizeWithDelegate: [PaeDaeSharedPrizeDelegate sharedDelegate]];
	[[PaeDaeSDK sharedManager] showAd];
    }

    void _UpdatePlayerInfo()
    {

    }
}
