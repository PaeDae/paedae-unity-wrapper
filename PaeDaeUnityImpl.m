//
//  PaeDaeUnityImpl.m
//  
//
//  Created by Greg Morrison on 11/13/12.
//
//

#import "PaeDaeUnityImpl.h"
#import "PaeDaePrizeSDK.h"

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
    void _ShowPrize()
    {
        [[PaeDaePrizeSDK sharedManager] showPrize];
    }
}