//
//  PaeDaeUnityImpl.mm
//
//
//  Created by Greg Morrison on 11/13/12.
//  Copyright (c) 2012 PaeDae Inc. All rights reserved.
//

#import "PaeDaeUnityImpl.h"

@implementation PaeDaeUnity

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
    void _PaeDaeWrapperInit(const char* key)
    {
        [[PaeDaeSDK sharedManager] initWithKey:[NSString stringWithUTF8String:key] andDelegate:[PaeDaeSharedDelegate sharedDelegate]];
    }

    void _ShowAd(const char *zone_id)
    {
        NSDictionary *adOptions = [NSDictionary dictionaryWithObjectsAndKeys:
                                   [NSString stringWithUTF8String:zone_id], @"zone_id"
                                   , nil];
        [[PaeDaeSDK sharedManager] showAdWithOptions:options andDelegate:[PaeDaeSharedDelegate sharedDelegate]];
    }
}
